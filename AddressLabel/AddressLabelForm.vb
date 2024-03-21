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

    End Function




End Class
