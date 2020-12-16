Imports System
Imports System.Threading

Module Program
    Private ReadOnly month As Integer = 12
    Private step1 As Integer = 0
    Private step2 As Integer = 0
    Private step3 As Integer = 0
    Private step4 As Integer = 0
    Private ReadOnly sun As Integer = 0
    Private ReadOnly mon As Integer = 1
    Private ReadOnly tue As Integer = 2
    Private ReadOnly wed As Integer = 3
    Private ReadOnly thur As Integer = 4
    Private ReadOnly fri As Integer = 5
    Private ReadOnly sat As Integer = 6
    Private ReadOnly monthdivisor As Integer = 4
    Private ReadOnly monthday As Integer = 7
    Private result As Integer = 0
    Private anchorday As Integer = 0
    Private years As Integer = 0
    Private yeardif As Integer = 0
    Private doomsday As String
    Private finalday As String
    Private dif As Integer = 0
    Private final As Integer = 0
    Private dater As Integer = 0
    Private monther As Integer = 0
    Private yearer As Integer = 0
    Private ReadOnly dtlist As New List(Of Date)
    Private step_1 As Integer = 0
    Private rstart As ConsoleKeyInfo
    Private ReadOnly r As ConsoleKey = ConsoleKey.R

    Sub Main(args As String())
Strt:
        'Introducing app and Welcoming user
        Console.Clear()
        Console.WriteLine("Welcometo the Doomsday calculator!")
        Thread.Sleep(1000)
        Console.WriteLine("This program is made to calculate the day of any given date using the Doomsday Algorithm.")
        Console.WriteLine()
        'Taking input from user
        Console.WriteLine("Please enter the date(Press enter after writing the date, then after writing the month number and at last the year)")
        dater = Console.ReadLine()
        Console.WriteLine("The month now (month number)")
        monther = Console.ReadLine()
        Console.WriteLine("Now the year (it should be between 1800 and 2199)")
        yearer = Console.ReadLine()
        Console.WriteLine("One moment please...")
        'Starting calculation
        On Error GoTo Err
        'Date given by user
        Dim maindat As New DateTime(yearer, monther, dater)
        FormatDateTime(maindat, DateFormat.ShortDate)
        On Error GoTo Err
        'Adding Doomsday dates to a list
        dtlist.Add("03/07")
        dtlist.Add("05/09")
        dtlist.Add("09/05")
        dtlist.Add("04/04")
        dtlist.Add("06/06")
        dtlist.Add("08/08")
        dtlist.Add("10/10")
        dtlist.Add("12/12")
        dtlist.Add("11/07")
        dtlist.Add("07/11")
        'There are different dates for Jan and Feb in Leap years and Normal years
        If yearer Mod 4 = 0 Then
            dtlist.Add("01/04")
            dtlist.Add("02/29")
        Else
            dtlist.Add("01/03")
            dtlist.Add("02/28")
        End If

        On Error GoTo Err
        'Getting the century's Anchor Day 
        If yearer > 1999 AndAlso yearer < 2100 Then
            anchorday = tue
            yeardif = 2000
            years = yearer - yeardif
        ElseIf yearer > 1899 AndAlso yearer < 2000 Then
            anchorday = wed
            yeardif = 1900
            years = yearer - yeardif
        ElseIf yearer > 1799 AndAlso yearer < 1900 Then
            anchorday = fri
            yeardif = 1800
            years = yearer - yeardif
        ElseIf yearer > 2099 AndAlso yearer < 2200 Then
            anchorday = sun
            yeardif = 2100
            years = yearer - yeardif
        Else
            Console.WriteLine("ERROR!--INVALID_YEAR!")
            Console.WriteLine("Retry:")
            Thread.Sleep(3000)
            GoTo Strt
        End If

        Thread.Sleep(1000)
        'Math part start
        step1 = (years / month)
        If step1 > (years / month) Then
            step1 -= 1
        End If
        step2 = (years Mod month)
        step3 = (step2 / monthdivisor)
        If step3 > (step2 / monthdivisor) Then
            step3 -= 1
        End If
        step4 = (step1 + step2 + step3 + anchorday)
        step_1 = step4

        If step_1 >= 7 Then
            Do Until step_1 < 7
                step_1 -= monthday
            Loop
            result = step_1
        Else
            result = step4
        End If
        'Math part end
        'Doomsday of the year
        If result = sun Then
            doomsday = "Sunday"
        ElseIf result = mon Then
            doomsday = "Monday"
        ElseIf result = tue Then
            doomsday = "Tuesday"
        ElseIf result = wed Then
            doomsday = "Wednesday"
        ElseIf result = thur Then
            doomsday = "Thursday"
        ElseIf result = fri Then
            doomsday = "Friday"
        ElseIf result = sat Then
            doomsday = "Saturday"
        Else
Err:
            'Showing error if found any and restarting the program
            Console.WriteLine("ERROR!--INVALID_VALUE!")
            Console.WriteLine("Retry:")
            Thread.Sleep(3000)
            GoTo Strt
        End If

        On Error GoTo Err
        'Calculating the difference between a doomsday date and the user given date
        For Each dt In dtlist
            If dt.Month = monther Then
                Dim dtch As New DateTime(yearer, dt.Month, dt.Day)
                Dim diff As DateInterval = DateDiff(DateInterval.Day, dtch, maindat)
                If diff < 0 Then
                    diff *= -1
                End If
                dif = diff Mod 7
                If dif = 0 Then
                    final = result
                    Exit For
                End If
                If dtch.Day > maindat.Day Then
                    Do Until dif = 0
                        If result = 0 Then
                            result = 7
                        End If
                        result -= 1
                        dif -= 1
                    Loop
                ElseIf dtch.Day < maindat.Day Then
                    Do Until dif = 0
                        If result = 7 Then
                            result = 0
                        End If
                        result += 1
                        dif -= 1
                    Loop
                    If result = 7 Then
                        result = 0
                    End If
                End If
            End If
        Next
        'Determining the day of the date given by user
        final = result
        If final = sun Then
            finalday = "Sunday"
        ElseIf final = mon Then
            finalday = "Monday"
        ElseIf final = tue Then
            finalday = "Tuesday"
        ElseIf final = wed Then
            finalday = "Wednesday"
        ElseIf final = thur Then
            finalday = "Thursday"
        ElseIf final = fri Then
            finalday = "Friday"
        ElseIf final = sat Then
            finalday = "Saturday"
        Else
            Console.WriteLine("ERROR!--INVALID_VALUE!")
            Console.WriteLine("Retry:")
            Thread.Sleep(3000)
            GoTo Strt
        End If

        On Error GoTo Err
        'Giving the answer to the user
        Dim finaldaystr As String = finalday.ToString
        Dim maindaystr As String = maindat.ToString("d")
        Console.WriteLine($"On {maindaystr} It was {finaldaystr}. Doomsday was {doomsday}")
        'Asking the user if he wants to find the day of another date
        Console.WriteLine("If you want to restart the program and try a different day, press 'r'. Press any other key to exit...")
        rstart = Console.ReadKey()
        If rstart.Key = r Then
            rstart = Nothing
            years = Nothing
            yearer = Nothing
            yeardif = Nothing
            monther = Nothing
            dater = Nothing
            step1 = Nothing
            step2 = Nothing
            step3 = Nothing
            step4 = Nothing
            step_1 = Nothing
            dif = Nothing
            result = Nothing
            anchorday = Nothing
            final = Nothing
            GoTo Strt
        Else
            Console.WriteLine("GoodBye user! Comeback soon!")
            Thread.Sleep(2000)
            Console.Clear()
            Console.WriteLine("Made by Metarya")
            Console.WriteLine("v1.0")
            'Not sure if I should add this
            'Console.WriteLine("For feedback and suggestions, mail me on 'cagbaid@gmail.com'")
            Thread.Sleep(4000)
            End
        End If

    End Sub
End Module
