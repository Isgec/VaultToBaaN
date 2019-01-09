Imports System.Runtime.InteropServices
Public Class winApi
  Private Declare Auto Function IsIconic Lib "user32.dll" (ByVal hwnd As IntPtr) As Boolean
  <DllImport("user32.dll", SetLastError:=True)> _
  Private Shared Function MoveWindow(ByVal hWnd As IntPtr, ByVal X As Integer, ByVal Y As Integer, _
    ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal bRepaint As Boolean) As Boolean
  End Function
  Public Structure RECT
    Dim Left As Integer
    Dim Top As Integer
    Dim Right As Integer
    Dim Bottom As Integer
  End Structure
  Public Declare Function GetWindowRect Lib "user32" (ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
  Public Shared Function GetWindowLocation(ByVal hWnd As IntPtr) As System.Drawing.Point
    Dim r As RECT
    GetWindowRect(hWnd, r)
    Return New System.Drawing.Point(r.Left, r.Top)
  End Function
  Public Function GetLocationWithinScreen(ByVal Name As Drawing.Point) As String
    For Each Display As Screen In Screen.AllScreens
      If Display.Bounds.Contains(Name.X - Name.X, Name.Y - Name.Y) Then ' May need to remove - Name.x and - Name.y
        Return Display.DeviceName.ToString
      End If
    Next
    Return Nothing
  End Function
  Public Shared Function GetAppLocation(ByVal hwnd As IntPtr) As Screen
    Return Screen.FromHandle(hwnd)
  End Function
  <DllImport("user32.dll")> _
  Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
  End Function
  <DllImport("user32.dll", SetLastError:=True)> _
  Private Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As Integer
  End Function
  <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Shared Function FindWindow( ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
  End Function
  <DllImport("user32.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Shared Function FindWindowByClass(ByVal lpClassName As String, ByVal zero As IntPtr) As IntPtr
  End Function
  <DllImport("user32.dll", EntryPoint:="FindWindow", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Shared Function FindWindowByCaption(ByVal zero As IntPtr, ByVal lpWindowName As String) As IntPtr
  End Function
  <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Shared Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
  End Function
End Class
'Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
'  ListView1.View = View.Details
'  ListView1.LabelEdit = True
'  ListView1.AllowColumnReorder = True
'  ListView1.CheckBoxes = False
'  ListView1.FullRowSelect = True
'  ListView1.GridLines = True
'  ListView1.Sorting = SortOrder.Ascending

  '  'ListView1.Columns.Add("Process Name", 100, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Main Window Title", 400, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Location Within Screen", 150, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Display name", 120, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Item Main Window Handle", 200, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Process Name", 300, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Main Window Handle", 120, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Main Window Title", 400, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Process ID", 70, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Is process Minimized", 120, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Item handle", 70, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Screen name", 100, HorizontalAlignment.Left)

  'End Sub
  'Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
  '  ListView1.Clear()
  '  'ListView1.Columns.Add("Process Name", 100, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Main Window Title", 200, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Location Within Screen", 150, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Display name", 120, HorizontalAlignment.Left)
  '  'ListView1.Columns.Add("Item Main Window Handle", 200, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Process Name", 300, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Main Window Handle", 120, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Main Window Title", 400, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Process ID", 70, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Is process Minimized", 120, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Item handle", 70, HorizontalAlignment.Left)
  '  ListView1.Columns.Add("Screen name", 100, HorizontalAlignment.Left)

  '  'Dim p As Process() = Process.GetProcesses()
  '  'For Each Item As Process In p
  '  '  If Not Item.MainWindowHandle.ToInt32 = 0 Then
  '  '    If p.Length > 0 Then
  '  '      Dim Test2 As New Point(GetWindowLocation(Item.MainWindowHandle).X, GetWindowLocation(Item.MainWindowHandle).Y)
  '  '      Dim item1 As New ListViewItem(Item.ProcessName, 0)
  '  '      item1.SubItems.Add(Item.MainWindowTitle)
  '  '      item1.SubItems.Add(Test2.ToString)
  '  '      item1.SubItems.Add(GetLocationWithinScreen(Test2))
  '  '      item1.SubItems.Add(Item.MainWindowHandle.ToString)
  '  '      ListView1.Items.AddRange(New ListViewItem() {item1})
  '  '    End If
  '  '  End If
  '  'Next
  '  Dim pr As New List(Of Process)(System.Diagnostics.Process.GetProcesses)
  '  For Each Item As Process In pr
  '    If Not Item.MainWindowHandle.ToInt32 = 0 Then
  '      Dim item1 As New ListViewItem(Item.ProcessName, 0)
  '      item1.SubItems.Add(Item.MainWindowHandle.ToString)
  '      item1.SubItems.Add(Item.MainWindowTitle.ToString)
  '      item1.SubItems.Add(Item.Id.ToString)
  '      item1.SubItems.Add(IsIconic(Item.MainWindowHandle).ToString)
  '      item1.SubItems.Add(Item.Handle.ToString)
  '      item1.SubItems.Add(GetAppLocation(Item.Handle).DeviceName.ToString)
  '      ListView1.Items.AddRange(New ListViewItem() {item1})
  '    End If
  '  Next
  'End Sub
  'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
  '  Dim hWnd As IntPtr = FindWindow(Nothing, "AutoCAD") ' Calculator is Windows calc title text
  '  'MoveWindow(hWnd, 100, 200, 300, 400, True)
  '  Try
  '    SetForegroundWindow(hWnd)
  '    SendKeys.SendWait("{Enter}")
  '  Catch ex As Exception

  '  End Try

  'End Sub
  'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
  '  Dim hWnd As IntPtr = FindWindow(Nothing, "Vault-BaaN EDI")
  '  If Not hWnd.Equals(IntPtr.Zero) Then
  '    Dim prcID As Integer
  '    GetWindowThreadProcessId(hWnd, prcID)
  '    Dim Item As Process = Process.GetProcessById(prcID)

  '    Dim item1 As New ListViewItem(Item.ProcessName, 0)
  '    item1.SubItems.Add(Item.MainWindowHandle.ToString)
  '    item1.SubItems.Add(Item.MainWindowTitle.ToString & hWnd.ToString)
  '    item1.SubItems.Add(Item.Id.ToString)
  '    item1.SubItems.Add(IsIconic(Item.MainWindowHandle).ToString)
  '    item1.SubItems.Add(Item.Handle.ToString)
  '    item1.SubItems.Add(GetAppLocation(Item.Handle).DeviceName.ToString)
  '    ListView1.Items.AddRange(New ListViewItem() {item1})
  '  End If

  'End Sub

'Public Declare Function EnumChildWindows Lib "User32" (ByVal hwndParent As Long, ByVal lpEnumFunc As Long, ByVal lParam As Long) As Long
'Public Declare Function GetWindowText Lib "User32" Alias "GetWindowTextA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cchar As Long) As Long
'Public Declare Function GetWindowTextLength Lib "User32" Alias "GetWindowTextLengthA" (ByVal hwnd As Long) As Long
'Public Declare Function GetClassName Lib "User32" Alias "GetClassNameA" (ByVal hwnd As Long, ByVal lpString As String, ByVal cchar As Long) As Long
'Public Declare Function GetWindowLong Lib "User32" Alias "GetWindowLongA" (ByVal hwnd As Long, ByVal nindex As Long) As Long

''Const for Dialog (Form) Data
'Const GWL_WNDPROC = -4
'Const GWL_HINSTANCE = -6
'Const GWL_HWNDPARENT = -8
'Const GWL_STYLE = -16
'Const GWL_EXSTYLE = -20
'Const GWL_USERDATA = -21
'Const GWL_ID = -12


'Public Function EnumWindowProc(ByVal hwnd As Long, ByVal lParam As Long) As Long
'  Dim ControlText As String
'  Dim ClassName As String

'  ControlText = Space(GetWindowTextLength(hwnd) + 1)
'  ClassName = Space(256)
'  GetWindowText(hwnd, ControlText, Len(ControlText))
'  GetClassName(hwnd, ClassName, Len(ClassName))
'  Debug.Print("Controls Text:" & ControlText)
'  Debug.Print("Controls ClassName:" & ClassName)
'  Debug.Print("Controls ID:" & GetWindowLong(hwnd, GWL_ID))
'  'continue to enumerate
'  EnumWindowProc = 1
'  '0 would stop it.
'End Function

#Region " Sample Code "
'Imports System.Data
'004
'	Imports System.Drawing
'005
'	Imports System.Text
'006
'	Imports System.Windows.Forms
'007
'	Imports System.Runtime.InteropServices
'008
'	Imports System.Diagnostics
'009
'	Imports System.Reflection
'010
'	Imports System.IO
'011

'012
'Public Class MainForm
'013

'014
'#Region "Win32 API Declarations"
'015

'016
'	    <StructLayout(LayoutKind.Sequential)> _
'017
'  Public Structure RECT
'018
'    Public Left As Integer
'019
'    Public Top As Integer
'020
'    Public Right As Integer
'021
'    Public Bottom As Integer
'022
'  End Structure
'023

'024
'	    <StructLayout(LayoutKind.Sequential)> _
'025
'  Public Structure POINT
'026
'    Public X As Integer
'027
'    Public Y As Integer
'028

'029
'#Region "Helper methods"
'030

'031
'    Public Sub New(ByVal x As Integer, ByVal y As Integer)
'32:
'      Me.X = x
'33:
'      Me.Y = y
'34:
'    End Sub
'035

'036
'    Public Shared Widening Operator CType(ByVal p As POINT) As System.Drawing.Point
'37:
'      Return New System.Drawing.Point(p.X, p.Y)
'38:
'    End Operator
'039

'040
'    Public Shared Widening Operator CType(ByVal p As System.Drawing.Point) As POINT
'41:
'      Return New POINT(p.X, p.Y)
'42:
'    End Operator
'043

'044
'#End Region
'045
'  End Structure
'046

'047
'  Const DSTINVERT As Integer = &H550009
'048
'  Private Delegate Function EnumWindowsProc(ByVal hWnd As IntPtr, ByRef lParam As IntPtr) As Boolean
'049
'	    <DllImport("user32.dll", CharSet:=CharSet.Auto)> _
'050
'  Private Shared Function EnumChildWindows(ByVal hWndParent As System.IntPtr, ByVal lpEnumFunc As EnumWindowsProc, ByVal lParam As Integer) As Boolean
'51:
'  End Function
'052

'053
'	    <DllImport("gdi32.dll")> _
'054
'  Private Shared Function PatBlt(ByVal hdc As IntPtr, ByVal nXLeft As Integer, ByVal nYLeft As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal dwRop As UInteger) As Boolean
'55:
'  End Function
'056

'057
'	    <DllImport("user32.dll")> _
'058
'  Private Shared Function WindowFromPoint(ByVal Point As POINT) As IntPtr
'59:
'  End Function
'060

'061
'	    <DllImport("user32.dll")> _
'062
'  Private Shared Function GetWindowText(ByVal hWnd As Integer, ByVal text As StringBuilder, ByVal count As Integer) As Integer
'63:
'  End Function
'064

'065
'	    <DllImport("user32.dll")> _
'066
'  Private Shared Function GetWindowDC(ByVal hWnd As IntPtr) As IntPtr
'67:
'  End Function
'068

'069
'	    <DllImport("user32.dll")> _
'070
'  Private Shared Function GetWindowRect(ByVal hWnd As IntPtr, ByRef lpRect As RECT) As Boolean
'71:
'  End Function
'072

'073
'	    <DllImport("user32.dll")> _
'074
'  Private Shared Function OffsetRect(ByRef lprc As RECT, ByVal dx As Integer, ByVal dy As Integer) As Boolean
'75:
'  End Function
'076

'077
'	    <DllImport("user32.dll")> _
'078
'  Private Shared Function GetClassName(ByVal hWnd As IntPtr, ByVal lpClassName As StringBuilder, ByVal nMaxCount As Integer) As Integer
'79:
'  End Function
'080

'081
'	    <DllImport("user32.dll")> _
'082
'  Private Shared Function GetWindowThreadProcessId(ByVal hWnd As IntPtr, ByRef lpdwProcessId As Integer) As UInteger
'83:
'  End Function
'084

'085
'#End Region
'086

'087
'  Private _dragging As Boolean
'088
'  Private _hWndCurrent As IntPtr
'089
'  Private _contextMenu As ContextMenuStrip
'090
'  Private _browse As ToolStripMenuItem
'091
'  Private _cancel As ToolStripMenuItem
'092
'  Private _imgAppCross As Image
'093
'  Private _imgApp As Image
'094
'  Private _curCross As Cursor
'095

'096
'  Private Sub DrawRevFrame(ByVal hWnd As IntPtr)
'97:
'    If hWnd = IntPtr.Zero Then
'98:
'      Return
'99:
'    End If
'100:

'101:
'    Dim hdc As IntPtr = GetWindowDC(hWnd)
'102:
'    Dim rect As RECT
'103:
'    GetWindowRect(hWnd, rect)
'104:
'    OffsetRect(rect, -rect.Left, -rect.Top)
'105:

'106:
'    Const frameWidth As Integer = 3
'107:

'108:
'    PatBlt(hdc, rect.Left, rect.Top, rect.Right - rect.Left, frameWidth, DSTINVERT)
'109:
'    PatBlt(hdc, rect.Left, rect.Bottom - frameWidth, frameWidth, -(rect.Bottom - rect.Top - 2 * frameWidth), DSTINVERT)
'110:
'    PatBlt(hdc, rect.Right - frameWidth, rect.Top + frameWidth, frameWidth, rect.Bottom - rect.Top - 2 * frameWidth, DSTINVERT)
'111:
'    PatBlt(hdc, rect.Right, rect.Bottom - frameWidth, -(rect.Right - rect.Left), frameWidth, DSTINVERT)
'112:
'  End Sub
'113

'114
'  Private Function GetWindowText(ByVal hWnd As IntPtr) As String
'115:
'    Dim text As New StringBuilder(256)
'116:
'    If GetWindowText(hWnd.ToInt32(), text, text.Capacity) > 0 Then
'117:
'      Return text.ToString()
'118:
'    End If
'119:

'120:
'    Return [String].Empty
'121:
'  End Function
'122

'123
'  Private Function GetClassName(ByVal hWnd As IntPtr) As String
'124:
'    Dim className As New StringBuilder(100)
'125:
'    If GetClassName(hWnd, className, className.Capacity) > 0 Then
'126:
'      Return className.ToString()
'127:
'    End If
'128:

'129:
'    Return [String].Empty
'130:
'  End Function
'131

'132
'  Private Function GetApplication(ByVal hWnd As IntPtr) As String
'133:
'    Dim procId As Integer
'134:
'    GetWindowThreadProcessId(hWnd, procId)
'135:
'    Dim proc As Process = Process.GetProcessById(procId)
'136:
'    Return proc.MainModule.ModuleName
'137:
'  End Function
'138

'139
'  Private Function GetPath(ByVal hWnd As IntPtr) As String
'140:
'    Dim procId As Integer
'141:
'    Dim myProcessModule As ProcessModule
'142:
'    GetWindowThreadProcessId(hWnd, procId)
'143:
'    Dim proc As Process = Process.GetProcessById(procId)
'144:
'    myProcessModule = proc.MainModule
'145:
'    Return myProcessModule.FileName
'146:
'  End Function
'147

'148
'  Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'149:

'150:
'    Dim x As Control ' checks the type of a control
'151:
'    x = TextBox1
'152:
'    If TypeOf x Is Button Then
'153:
'      'MsgBox("button")
'154:
'    Else
'155:
'      'MsgBox("not button")
'156:
'    End If
'157:

'158:
'    Dim assembly__1 As Assembly = Assembly.GetExecutingAssembly()
'159:
'    _imgAppCross = Image.FromStream(assembly__1.GetManifestResourceStream("TRY.app_cross.bmp"))
'160:
'    _imgApp = Image.FromStream(assembly__1.GetManifestResourceStream("TRY.app.bmp"))
'161:
'    _curCross = New Cursor(assembly__1.GetManifestResourceStream("TRY.cross.cur"))
'162:
'    dragPictureBox.Image = _imgAppCross
'163:
'  End Sub
'164

'165
'  Private Sub dragPictureBox_MouseDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dragPictureBox.MouseDown
'166:
'    If e.Button = MouseButtons.Right Then
'167:
'      _dragging = True
'168:
'      Me.Cursor = _curCross
'169:
'      dragPictureBox.Image = _imgApp
'170:
'    End If
'171:
'  End Sub
'172

'173
'  Private Sub dragPictureBox_MouseUp_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dragPictureBox.MouseUp
'174:
'    If _dragging Then
'175:
'      _dragging = False
'176:
'      Me.Cursor = Cursors.[Default]
'177:
'      If _hWndCurrent <> IntPtr.Zero Then
'178:
'        DrawRevFrame(_hWndCurrent)
'179:
'        _hWndCurrent = IntPtr.Zero
'180:
'      Else
'181:
'        dragPictureBox.Image = _imgAppCross
'182:
'      End If
'183:
'    End If
'184:
'  End Sub
'185

'186
'  Private Sub dragPictureBox_MouseMove_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dragPictureBox.MouseMove
'187:
'    If _dragging Then
'188:
'      Dim hWnd As IntPtr = WindowFromPoint(MousePosition) '
'189:
'      If hWnd = dragPictureBox.Handle Then
'190:
'        ' Drawing a border around the dragPictureBox (where we start
'191:
'        ' dragging) doesn't look nice, so we ignore this window
'192:
'        hWnd = IntPtr.Zero
'193:
'      End If
'194:

'195:
'      If hWnd <> _hWndCurrent Then
'196:
'        If _hWndCurrent <> Nothing Then
'197:
'          DrawRevFrame(_hWndCurrent)
'198:
'        End If
'199:
'        DrawRevFrame(hWnd)
'200:
'        _hWndCurrent = hWnd
'201:
'      End If
'202:

'203:
'      If hWnd <> IntPtr.Zero Then
'204:
'        txtWindowHandle.Text = hWnd.ToString()
'205:
'        txtWindowText.Text = GetWindowText(hWnd)
'206:
'        txtClassName.Text = GetClassName(hWnd)
'207:
'        txtApplication.Text = GetApplication(hWnd)
'208:
'        TextBox1.Text = GetPath(hWnd)
'209:
'      Else
'210:
'        txtWindowHandle.Text = [String].Empty
'211:
'        txtWindowText.Text = [String].Empty
'212:
'        txtClassName.Text = [String].Empty
'213:
'        txtApplication.Text = [String].Empty
'214:
'        TextBox1.Text = [String].Empty
'215:
'      End If
'216:
'    End If
'217:
'  End Sub
'218
'End Class
#End Region

#Region " Sample Code 2 "
'Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" _
'(ByVal lpClassName As String, ByVal lpWindowName As String) As Long

'Private Declare Function FindWindowEx Lib "user32" Alias "FindWindowExA" _
'(ByVal hWnd1 As Long, ByVal hWnd2 As Long, ByVal lpsz1 As String, _
'ByVal lpsz2 As String) As Long

'Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" _
'(ByVal hwnd As Long, ByVal lpString As String, ByVal cch As Long) As Long

'Private Declare Function GetWindowTextLength Lib "user32" Alias _
'"GetWindowTextLengthA" (ByVal hwnd As Long) As Long

'Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
'(ByVal hwnd As Long, ByVal wMsg As Long, ByVal wParam As Long, ByVal lParam As Any) As Long

'Const BM_CLICK = &HF5&

'Dim Ret As Long, ChildRet As Long, OpenRet As Long
'Dim strBuff As String, ButCap As String

'Sub Sample()
'  '~~> Get the handle of the "File Download" Window
'  Ret = FindWindow(vbNullString, "File Download")

'  If Ret <> 0 Then
'    MsgBox("Main Window Found")

'    '~~> Get the handle of the Button's "Window"
'        ChildRet = FindWindowEx(Ret, ByVal 0&, "Button", vbNullString)

'    '~~> Check if we found it or not
'    If ChildRet <> 0 Then
'      MsgBox("Child Window Found")

'      '~~> Get the caption of the child window
'            strBuff = String(GetWindowTextLength(ChildRet) + 1, Chr$(0))
'      GetWindowText(ChildRet, strBuff, Len(strBuff))
'      ButCap = strBuff

'      '~~> Loop through all child windows
'      Do While ChildRet <> 0
'        '~~> Check if the caption has the word "Open"
'        '~~> For "Save" or "Cancel", replace "Open" with
'        '~~> "Save" or "Cancel"
'        If InStr(1, ButCap, "Open") Then
'          '~~> If this is the button we are looking for then exit
'          OpenRet = ChildRet
'          Exit Do
'        End If

'        '~~> Get the handle of the next child window
'        ChildRet = FindWindowEx(Ret, ChildRet, "Button", vbNullString)
'        '~~> Get the caption of the child window
'                strBuff = String(GetWindowTextLength(ChildRet) + 1, Chr$(0))
'        GetWindowText(ChildRet, strBuff, Len(strBuff))
'        ButCap = strBuff
'      Loop

'      '~~> Check if we found it or not
'      If OpenRet <> 0 Then
'        MsgBox("The Handle of Open Button is : " & OpenRet)
'        '~~> Click the button using Send Message
'        SendMessage(OpenRet, BM_CLICK, 0, 0)
'      Else
'        MsgBox("The Handle of Open Button was not found")
'      End If
'    Else
'      MsgBox("Child Window Not Found")
'    End If
'  Else
'    MsgBox("Window Not Found")
'  End If
'End Sub
#End Region

#Region "Sample Code 3 "


Public Class FindWindowHandle

#Region " User32 Functions "

  ''' <summary>
  ''' Retrieves a handle to the top-level window whose class name and window name
  ''' match the specified strings. This function does not search child windows.
  ''' This function does not perform a case-sensitive search.
  ''' </summary>
  ''' <param name="lpClassName"></param>
  ''' <param name="lpWindowName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <DllImport("User32.dll")> _
  Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As Integer
  End Function

  ''' <summary>
  ''' Retrieves a handle to a window whose class name and window name match the specified strings.
  ''' The function searches child windows, beginning with the one following the specified child window.
  ''' This function does not perform a case-sensitive search.
  ''' </summary>
  ''' <param name="parentHandle"></param>
  ''' <param name="childAfter"></param>
  ''' <param name="lpszClass"></param>
  ''' <param name="lpszWindow"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> _
  Private Shared Function FindWindowEx(ByVal parentHandle As IntPtr, ByVal childAfter As IntPtr, _
                     ByVal lpszClass As String, ByVal lpszWindow As String) As IntPtr
  End Function

#End Region

#Region " Vars "

  ''' <summary>
  ''' The class name or a class atom created by a previous call to the RegisterClass or RegisterClassEx function.
  ''' If ClassName points to a string, it specifies the window class name.
  ''' The class name can be any name registered with RegisterClass or RegisterClassEx, or any of the predefined control-class names.
  ''' If ClassName is NULL, it finds any window whose title matches the WindowName parameter.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Shared Property ClassName As String

  ''' <summary>
  ''' The window name (the window's title). If this parameter is NULL, all window names match.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Shared Property WindowName As String

  ''' <summary>
  ''' A handle to the parent window whose child windows are to be searched.
  ''' If Parent is NULL, the function uses the desktop window as the parent window.
  ''' The function searches among windows that are child windows of the desktop.
  ''' If Parent is HWND_MESSAGE, the function searches all message-only windows.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Shared Property ParentHandle As IntPtr

  ''' <summary>
  ''' A handle to a child window. The search begins with the next child window in the Z order.
  ''' The child window must be a direct child window of Parent, not just a descendant window.
  ''' If ChildAfter is NULL, the search begins with the first child window of Parent.
  ''' Note that if both Parent and ChildAfter are NULL, the function searches all top-level and
  ''' message-only windows.
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Shared Property ChildHandle As IntPtr

#End Region

  Public Shared ReadOnly Property hwnd_DesktopIcons As IntPtr
    Get
      Return FindWindowEx(IntPtr.Zero, IntPtr.Zero, "Progman", vbNullString)
    End Get
  End Property

  Public Shared ReadOnly Property hwnd_StartBar As IntPtr
    Get
      Return FindWindow("Shell_traywnd", vbNullString)
    End Get
  End Property

  Public Shared ReadOnly Property hwnd_StartBarOrb As IntPtr
    Get
      Return FindWindow("Button", vbNullString)
    End Get
  End Property

  Class GetIt

    Public Shared Function by_ClassName(ByVal value As String)
      Try
        ClassName = value
        Return FindWindow(ClassName, vbNull)
      Catch ex As Exception
        Return vbNull
      End Try
    End Function

    Public Shared Function by_WindowName(ByVal value As String)
      Try
        WindowName = value
        Return FindWindow(vbNull, WindowName)
      Catch ex As Exception
        Return vbNull
      End Try
    End Function

    Public Shared Function by_WindowNameAndClassName(ByVal v_ClassName As String, ByVal v_WindowName As String)
      Try
        ClassName = v_ClassName
        WindowName = v_WindowName
        Return FindWindow(ClassName, WindowName)
      Catch ex As Exception
        Return vbNull
      End Try
    End Function

    Public Shared Function byChildHandle(ByVal v_ChildHandle As IntPtr)
      Try
        ChildHandle = v_ChildHandle
        Return FindWindowEx(IntPtr.Zero, ChildHandle, vbNullString, vbNullString)
      Catch ex As Exception
        Return vbNull
      End Try
    End Function

    Public Shared Function byParentHandle(ByVal v_ParentHandle As IntPtr)
      Try
        ParentHandle = v_ParentHandle
        Return FindWindowEx(ParentHandle, IntPtr.Zero, vbNullString, vbNullString)
      Catch ex As Exception
        Return vbNull
      End Try
    End Function

    Class _byChildHandleAnd

      Public Shared Function andClassName(ByVal v_ChildHandle As IntPtr, _
                              ByVal v_ClassName As String)
        Try
          ChildHandle = v_ChildHandle
          ClassName = v_ClassName
          Return FindWindowEx(IntPtr.Zero, ChildHandle, ClassName, vbNullString)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function andWindowName(ByVal v_ChildHandle As IntPtr, _
                              ByVal v_WindowName As String)
        Try
          ChildHandle = v_ChildHandle
          WindowName = v_WindowName
          Return FindWindowEx(IntPtr.Zero, ChildHandle, vbNullString, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function WindowAndClassName(ByVal v_ChildHandle As IntPtr, _
                              ByVal v_ClassName As String, ByVal v_WindowName As String)
        Try
          ChildHandle = v_ChildHandle
          ClassName = v_ClassName
          WindowName = v_WindowName
          Return FindWindowEx(IntPtr.Zero, ChildHandle, ClassName, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

    End Class

    Class _byParentHandleAnd

      Public Shared Function andClassName(ByVal v_ParentHandle As IntPtr, _
                              ByVal v_ClassName As String)
        Try
          ParentHandle = v_ParentHandle
          ClassName = v_ClassName
          Return FindWindowEx(ParentHandle, IntPtr.Zero, ClassName, vbNullString)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function andWindowName(ByVal v_ParentHandle As IntPtr, _
                              ByVal v_WindowName As String)
        Try
          ParentHandle = v_ParentHandle
          WindowName = v_WindowName
          Return FindWindowEx(ParentHandle, IntPtr.Zero, vbNullString, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function WindowAndClassName(ByVal v_ParentHandle As IntPtr, _
                              ByVal v_ClassName As String, ByVal v_WindowName As String)
        Try
          ParentHandle = v_ParentHandle
          ClassName = v_ClassName
          WindowName = v_WindowName
          Return FindWindowEx(ParentHandle, IntPtr.Zero, ClassName, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

    End Class

  End Class

  Class Search

    Class Desktop

      Public Shared Function byClassName(ByVal value As String)
        Try
          ClassName = value
          Return FindWindowEx(IntPtr.Zero, IntPtr.Zero, ClassName, vbNullString)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byWindowName(ByVal value As String)
        Try
          WindowName = value
          Return FindWindowEx(IntPtr.Zero, IntPtr.Zero, vbNullString, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byWindowAndClassName(ByVal v_ClassName As String, ByVal v_WindowName As String)
        Try
          ClassName = v_ClassName
          WindowName = v_WindowName
          Return FindWindowEx(IntPtr.Zero, IntPtr.Zero, ClassName, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

    End Class

    Class MessageOnlyWindows

      Public Shared HWND_MESSAGE As IntPtr = New IntPtr(-3)

      Public Shared Function byClassName(ByVal value As String)
        Try
          ClassName = value
          Return FindWindowEx(HWND_MESSAGE, IntPtr.Zero, ClassName, vbNullString)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byClassName(ByVal StartingChildHandle As IntPtr, ByVal value As String)
        Try
          ClassName = value
          ChildHandle = StartingChildHandle
          Return FindWindowEx(HWND_MESSAGE, ChildHandle, ClassName, vbNullString)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byWindowName(ByVal value As String)
        Try
          WindowName = value
          Return FindWindowEx(HWND_MESSAGE, IntPtr.Zero, vbNullString, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byWindowName(ByVal StartingChildHandle As IntPtr, ByVal value As String)
        Try
          WindowName = value
          ChildHandle = StartingChildHandle
          Return FindWindowEx(HWND_MESSAGE, ChildHandle, vbNullString, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byWindowAndClassName(ByVal v_ClassName As String, ByVal v_WindowName As String)
        Try
          ClassName = v_ClassName
          WindowName = v_WindowName
          Return FindWindowEx(HWND_MESSAGE, IntPtr.Zero, ClassName, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

      Public Shared Function byWindowAndClassName(ByVal StartingChildHandle As IntPtr, _
                              ByVal v_ClassName As String, ByVal v_WindowName As String)
        Try
          ClassName = v_ClassName
          WindowName = v_WindowName
          ChildHandle = StartingChildHandle
          Return FindWindowEx(HWND_MESSAGE, ChildHandle, ClassName, WindowName)
        Catch ex As Exception
          Return vbNull
        End Try
      End Function

    End Class

  End Class

End Class
#End Region