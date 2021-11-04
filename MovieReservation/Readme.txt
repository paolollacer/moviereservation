Movie Reservation App v1.1
by Juan Paolo Llacer

Setup (for MS SQL Mode):
- In the settings.txt file found at the application's Program Folder, set the value of "MSSQLmode" = true
- Configure values for SQL Server Name, User Name, Password, and Database Name on "settings.txt"

Setup (for MySQL Mode):
- In the settings.txt file found at the application's Program Folder, set the value of "MSSQLmode" = false
- Configure values for SQL Server Name, SQL Port, User Name, Password, and Database Name on "settings.txt"

How to Use:
- At the start-up screen, double-click each Cinema's Movie Title, Movie Poster Image, and Ticket Price to change their values
- Always include Customer User Name when saving a new seat reservation. Otherwise, an error message will appear
- No need to include Customer User Name when cancelling an existing seat reservation.