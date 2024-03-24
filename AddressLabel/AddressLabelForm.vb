'Owen Fujii
'RCET 2265
'Spring 2024
'Address Label
'https://github.com/Masaharu41/AddressLabel.git

Option Explicit On
Option Strict On

Imports System.Globalization
Public Class AddressLabelForm

    Private Sub StartUp(sender As Object, e As EventArgs) Handles Me.Load
        'Clears all displayed data on program load
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        DisplayLabel.Text = ""
    End Sub
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        'Exits the program 
        Me.Close()
    End Sub
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        'Displays the full display label
        DisplayLabel.Text = CreateDisplay()
    End Sub

    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        'Clears all Displayed Data
        DisplayLabel.Text = ""
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
    End Sub

    Function CreateDisplay() As String
        'function variables 
        Dim displayText As String
        Dim lettersOfFirst As String
        Dim lettersOfLast As String
        Dim fullName As String
        Dim fullAddress As String
        Dim onlyStateLetters As String
        Dim zipInt As Integer
        Dim formatErrorsTracker As String
        Dim formatErrors As String
        Dim foundError As Boolean
        Dim emptyFinder As Boolean
        'special dimention which calls the systems information about the users language
        'this is important for converting to ToTitleCase methods with the proper conventions for English
        Dim ti As TextInfo = CultureInfo.CurrentCulture.TextInfo

        emptyFinder = False
        'if statements that check that the incoming strings are present and not empty or null
        'code will not execute unless all information is inputed 
        If String.IsNullOrEmpty(FirstNameTextBox.Text) Then
            emptyFinder = True
            formatErrorsTracker = "First Name cannot be empty" & vbNewLine
            formatErrors = formatErrorsTracker
        End If
        If String.IsNullOrEmpty(LastNameTextBox.Text) Then
            emptyFinder = True
            formatErrorsTracker = formatErrors & "Last Name cannot be empty" & vbNewLine
            formatErrors = formatErrorsTracker
        End If
        If String.IsNullOrEmpty(StreetAddressTextBox.Text) Then
            emptyFinder = True
            formatErrorsTracker = formatErrors & "Address cannot be empty" & vbNewLine
            formatErrors = formatErrorsTracker
        End If
        If String.IsNullOrEmpty(CityTextBox.Text) Then
            emptyFinder = True
            formatErrorsTracker = formatErrors & "City cannot be empty" & vbNewLine
            formatErrors = formatErrorsTracker
        End If
        If String.IsNullOrEmpty(StateTextBox.Text) Then
            emptyFinder = True
            formatErrorsTracker = formatErrors & "State cannot be empty" & vbNewLine
            formatErrors = formatErrorsTracker
        End If
        If String.IsNullOrEmpty(ZipTextBox.Text) Then
            emptyFinder = True
            formatErrorsTracker = formatErrors & "Zip cannot be empty" & vbNewLine
            formatErrors = formatErrorsTracker
        End If
        'if there were no errors found the the primary code will be executed
        'the purpose of the code is to include as many built in tools which will
        'automatically resolve user format errors or issue warnings when inputed
        'data is not valid for an address
        If emptyFinder = False Then

            'two methods which convert the inputs from the name textboxs into only their letter components

            lettersOfFirst = String.Concat(FirstNameTextBox.Text.Where(AddressOf Char.IsLetter))
            lettersOfLast = String.Concat(LastNameTextBox.Text.Where(AddressOf Char.IsLetter))

            'Concatenates the first and last names as only letters into one variable
            fullName = FirstLetterUpper(lettersOfFirst) & " " & FirstLetterUpper(lettersOfLast)

            'a try catch which checks that the zip code is only integer values
            Try
                zipInt = CInt(ZipTextBox.Text)
            Catch ex As Exception
                formatErrorsTracker = "Zip can only be numbers" & vbNewLine
                formatErrors = formatErrorsTracker
                foundError = True
            End Try
            'Requires that the state is only two letters long and converts to letters only

            onlyStateLetters = String.Concat(StateTextBox.Text.Where(AddressOf Char.IsLetter))

            If Len(onlyStateLetters) = 2 Then

                fullAddress = ti.ToTitleCase(CityTextBox.Text) & ", " & UCase(onlyStateLetters) & " " & zipInt
            Else
                formatErrorsTracker = formatErrors & "Please use the State Abbreviation" & vbNewLine
                formatErrors = formatErrorsTracker

                foundError = True
            End If
            'Display will only be shown if there are no errors with the inputs
            If foundError = False Then
                displayText = fullName & vbNewLine & ti.ToTitleCase(StreetAddressTextBox.Text) & vbNewLine & fullAddress
            ElseIf foundError = True Then
                MsgBox(formatErrorsTracker)
                displayText = ""
            End If

            Return displayText
        Else
            MsgBox(formatErrors)
            Return ""
        End If
    End Function

    Function FirstLetterUpper(Val As String) As String
        'this function converts the inputed string into char to convert the first
        'letter to upper case and will exit if the string is an empty value
        If String.IsNullOrEmpty(Val) Then
            Return Val
        End If

        Dim array() As Char = Val.ToCharArray

        array(0) = Char.ToUpper(array(0))

        Return array
    End Function


End Class
