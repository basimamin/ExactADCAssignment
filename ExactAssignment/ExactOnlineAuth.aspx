<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExactOnlineAuth.aspx.cs" Inherits="ExactAssignment.ExactOnlineAuth" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exact Online Authenticartion</title>
    <script type="text/javascript">
        if(<%=CodeReturned%>)
        {
            window.opener.location.reload();
            //window.opener.location.href = window.opener.location.href;
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
