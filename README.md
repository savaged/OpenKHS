# OpenKHS

Free open source KHS (Kingdom Hall Scheduling) application. Totally free - no "donations"!

Currently just a work in progress. Heavily leverages patterns for loose coupling to allow for testing and future extensibility.

Feel free to have a look at the code by cloning this repository using:

* `git clone https://github.com/savaged/OpenKHS.git OpenKHS`

## NOTES

* Decided to start over from the domain design up.
* One should expect `error NETSDK1100` if one tries to build the WPF project or the solution on Linux or Apple OS.

## TO DO List

| Priority | T-shirt | Percent Done | Where | Description |
| --- | --- | --- | --- | --- |
| Must | L | Model | Assignment selection by list ordered by assignment tally |
| Should | XL | WPF | UI application |
| Should | M | CLI | Code the AddModule |
| Could | L | All | Add cleaning schedule |
| Could | XL | Android | Android UI version |
| Could | XL | iOS | Apple UI version |
| Could | L | WPF-Bridge | Windows Store UI version |
| Could | XL | Model | See if the privileges can be moved from hard-coded to db static data |
