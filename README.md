# OpenKHS #
Free open source KHS (Kingdom Hall Scheduling) application. Totally free - no "donations"!

Currently just a work in progress. Heavily leverages patterns for loose coupling to allow for testing and future extensibility.

Feel free to have a look at the code by cloning this repository using:

* `git clone https://github.com/savaged/OpenKHS.git OpenKHS`

## NOTES ##
* Sorry, I've not had time to do anything for ages but still aim to make this happen. Just dusted this off and found there's much to do

## TO DO List ##
* SHOW-STOPPER: Re-work all models to have relation IDs for EF to work
* Review use of service locator for view models
* UWP version using https://github.com/Microsoft/WindowsTemplateStudio
* Android version
* iOS version
* Functional Requirement: Add cleaning schedule
* Assignment selection by list ordered by assignment tally
* Publish method increments all assignees tally
* Adding new cong member resets everyones tally to lowest tally
