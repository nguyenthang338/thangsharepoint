Imports System
Imports System.ComponentModel
Imports System.Web.UI.WebControls.WebParts

<ToolboxItem(False)> _
Public Partial Class VisualWebPart1
    Inherits WebPart

    ' Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
    ' using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
    ' for production. Because the SecurityPermission attribute bypasses the security check for callers of
    ' your constructor, it's not recommended for production purposes.
    ' <System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode := True)> _
    Public Sub New()
    End Sub

    Protected Overrides Sub OnInit(ByVal e As System.EventArgs)
        MyBase.OnInit(e)
        InitializeControl()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

End Class

