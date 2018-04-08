using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace FileManager.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public bool AlreadyPopulated
        {
            get            
            {
                return (Session["AlreadyPopulated"] == null ? false : (bool) Session["AlreadyPopulated"]);
            }
            set
            {
                Session["AlreadyPopulated"] = (bool)value;
            }

        }

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// A method to populate a TreeView with directories, subdirectories, etc
        /// </summary>
        /// <param name="dir">The path of the directory</param>
        /// <param name="node">The "master" node, to populate</param>
        public void PopulateTree(string dir,  JsTreeModel node)
        {
            if (node.children == null)
            {
                node.children = new List<JsTreeModel>();
            } 
            // get the information of the directory
            DirectoryInfo directory = new DirectoryInfo(dir);
            // loop through each subdirectory
            foreach (DirectoryInfo d in directory.GetDirectories())
            {
                // create a new node
                JsTreeModel t = new JsTreeModel();
                t.attr = new JsTreeAttribute();
                t.attr.id = d.FullName;
                t.data = d.Name.ToString();
                // populate the new node recursively
                PopulateTree(d.FullName,  t);                              
                node.children.Add(t); // add the node to the "master" node
            }
            // lastly, loop through each file in the directory, and add these as nodes
            foreach (FileInfo f in directory.GetFiles())
            {
                // create a new node
                JsTreeModel t = new JsTreeModel();
                t.attr = new JsTreeAttribute();
                t.attr.id = f.FullName;
                t.data = f.Name.ToString();
               // add it to the "master"
                node.children.Add(t);
            }
        }      

                     
       [HttpPost]
        public JsonResult GetTreeData()
        {
            if (AlreadyPopulated == false)
            {
                JsTreeModel rootNode = new JsTreeModel();
                rootNode.attr = new JsTreeAttribute();
                rootNode.data = "ROOT";
                string rootPath = Request.MapPath("/Root");
                rootNode.attr.id = rootPath;
                PopulateTree(rootPath, rootNode);
                AlreadyPopulated = true;
                return Json(rootNode);
            }
            else
            {
                return null;
            }
        }

 
        [HttpPost]
        public ActionResult MoveData(string path, string destination)
        {
           // get the file attributes for file or directory
            FileAttributes attPath = System.IO.File.GetAttributes(path);

            FileAttributes attDestination = System.IO.File.GetAttributes(path);

            FileInfo fi = new FileInfo(path);

           //detect whether its a directory or file
           if ((attPath & FileAttributes.Directory) == FileAttributes.Directory)
            {
               if((attDestination & FileAttributes.Directory)==FileAttributes.Directory)
               {
                   MoveDirectory(path, destination);
               }                
            }
            else
            {
                System.IO.File.Move(path, destination + "\\" + fi.Name);
            }
            AlreadyPopulated = false;
            return null;   
        }

        [HttpPost]
        public ActionResult CreateFolder(string path, string newname)
        {
            Directory.CreateDirectory(path + "\\" + newname);
            AlreadyPopulated = false;
            return null;
        }
                

        public ActionResult Test()
        {
            return View();
        }

        public void MoveDirectory(string source, string target)
        {
            var stack = new Stack<Folders>();
            stack.Push(new Folders(source, target));

            while (stack.Count > 0)
            {
                var folders = stack.Pop();
                Directory.CreateDirectory(folders.Target);
                foreach (var file in Directory.GetFiles(folders.Source, "*.*"))
                {
                    string targetFile = Path.Combine(folders.Target, Path.GetFileName(file));
                    if (System.IO.File.Exists(targetFile)) System.IO.File.Delete(targetFile);
                    System.IO.File.Move(file, targetFile);
                }

                foreach (var folder in Directory.GetDirectories(folders.Source))
                {
                    stack.Push(new Folders(folder, Path.Combine(folders.Target, Path.GetFileName(folder))));
                }
            }
            Directory.Delete(source, true);
        }
        public class Folders
        {
            public string Source { get; private set; }
            public string Target { get; private set; }

            public Folders(string source, string target)
            {
                Source = source;
                Target = target;
            }
        }


    }
}
