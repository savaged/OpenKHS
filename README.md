# OpenKHS

Free open source KHS (Kingdom Hall Scheduling) application. Totally free - no "donations"!

Currently just a work in progress. Heavily leverages patterns for loose coupling to allow for testing and future extensibility.

Feel free to have a look at the code by cloning this repository using:

* `git clone https://github.com/savaged/OpenKHS.git OpenKHS`

## NOTES

* Decided to start over from the domain design up.
* One should expect `error NETSDK1100` if one tries to build the WPF project or the solution on Linux or Apple OS.

## TO DO List

| Priority | Size | ~% Done | Where | Description |
| --- | --- | --- | --- | --- |
| Must | L | 10 | Model | Assignment selection by list ordered by assignment tally |
| Should | S | 90 | All | Switch to NetStandard for each library |
| Should | XL | 55 | WPF | Desktop UI application (MS Windows, Mac OS and Linux) |
| Should | XL | 0 | WPF | Setup distribution of WPF application for MS Windows using Choclatey |
| Should | XL | 0 | WPF | Setup distribution of WPF application for Ubuntu based Linux distros using AptGet |
| Could | XL | 0 | Gtk# | Desktop UI application (MS Windows, Mac OS and Linux) that builds on Linux |
| Could | L | 0 | All | Add cleaning schedule |
| Could | M | 5 | TUI | Terminal User Interface version using [Gui.cs](https://github.com/migueldeicaza/gui.cs) |
| Could | XL | 0 | Android | Android UI version |
| Could | XL | 0 | iOS | Apple UI version |
| Could | L | 0 | WPF-Bridge | Windows Store UI version |
| Could | XL | 5 | Model | See if the privileges can be moved from hard-coded to db static data |
