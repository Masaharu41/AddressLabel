'Owen Fujii
'RCET 2265
'Spring 2024
'Address Label
'

Option Explicit On
Option Strict On

Public Class AddressLabelForm

    Private Sub StartUp(sender As Object, e As EventArgs) Handles Me.Load
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        DisplayLabel.Text = ""
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub

    Function CreateDisplay() As String
        Dim displayText As String
        Dim fullName As String
        Dim fullAddress As String

        fullName = FirstNameTextBox.Text & LastNameTextBox.Text
        If Len(StateTextBox.Text) = 2 Then
            fullAddress = CityTextBox.Text & "," & StateTextBox.Text & " " & ZipTextBox.Text
        Else
            MsgBox("Please use the State Abbreviation")
        End If
        displayText = fullName & vbNewLine & StreetAddressTextBox.Text & vbNewLine & fullAddress
        Return displayText
    End Function

    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        DisplayLabel.Text = CreateDisplay()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        DisplayLabel.Text = ""
    End Sub
End Class
