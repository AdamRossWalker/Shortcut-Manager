![Logo](Screenshots\shortcut-manager-logo.png "Logo")

# Shortcut Manager

This is a small WinForms application designed to replicate the old Windows task bar feature of cascading shortcut menus.  This was removed in Windows 11 and replaced with start menu groups.  These are harder to access, configure, and are not hierarchical.

This application is useful if you have many complex shortcuts that you need to organise, and/or you were reliant on the old behaviour.

![Main Window](Screenshots\shortcut-manager-main-window.png "Main Window")

![Popup Menu](Screenshots\shortcut-manager-popup.png "Popup Menu")

### Installation

This program is designed to be copied without an installer.  It does not write any shared files or registry settings.  However I can make no guarantees for Windows or .NET itself may do.

If you want this program to start when windows starts, please follow these instructions.

- Use the Windows+R shortcut key to open the run dialog box.  You can also open the Start Menu and type "Run" followed by Enter.
- Type in the following `shell:startup` followed by Enter.
- Create a shortcut to ShortcutManager.exe in this startup folder.
- Change the "Start in" folder to be the location where you would like the settings file saved.

### Settings Location

By default these are written to the current directory, in a file ShortcutManager.json.

If you have complex shortcuts I recommend backing this file up from time to time.
