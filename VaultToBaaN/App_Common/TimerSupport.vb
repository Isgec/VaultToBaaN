Imports System.Timers
Public MustInherit Class TimerSupport
  Private _tmr As Timer
  Private _stop As Boolean = False
  Private _Interval As Integer = 5000
  Public Property Interval() As Integer
    Get
      Return _Interval
    End Get
    Set(ByVal value As Integer)
      _Interval = value
    End Set
  End Property
  Public Sub Start()
    _tmr = New Timer
    AddHandler _tmr.Elapsed, New ElapsedEventHandler(AddressOf TimerFirst)
    _tmr.Interval = _Interval
    _tmr.Enabled = True
  End Sub
  Public Sub StopJob()
    _stop = True
  End Sub
  Private Sub TimerFirst(ByVal source As Object, ByVal e As ElapsedEventArgs)
    _tmr.Enabled = False
    RemoveHandler _tmr.Elapsed, New ElapsedEventHandler(AddressOf TimerFirst)
    If _stop Then
      _tmr = Nothing
      Stopped()
      Exit Sub
    End If
    Started()
    Process()
    AddHandler _tmr.Elapsed, New ElapsedEventHandler(AddressOf TimerTick)
    _tmr.Enabled = True
  End Sub
  Private Sub TimerTick(ByVal source As Object, ByVal e As ElapsedEventArgs)
    _tmr.Enabled = False
    If _stop Then
      _tmr = Nothing
      Stopped()
      Exit Sub
    End If
    Process()
    _tmr.Enabled = True
  End Sub
  Public MustOverride Sub Process()
  Public Overridable Sub Started()
  End Sub
  Public MustOverride Sub Stopped()
End Class
