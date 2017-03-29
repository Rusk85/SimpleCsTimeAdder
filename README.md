# SimpleCsTimeAdder
Very simple command line tool for adding up timespans such as 20:12, 1:1, 0:10 or 200:5000. Though the last one is untested but should be supported by the `TimeSpan` struct provided by C#.

# Requirements
- .NET Framework 4.5.2 >=
- MSBuild, Visual Studio or any other means for compiling

# Installation
1. Clone this repo
2. Build in Visual Studio
3. Run `TimeAdder.exe` from command line or any other way that supports passing in arguments (i.e. *.lnk-Files in Windows)

 
# Usage

**Interactive Mode**
	
		#> TimeAdder [-i|--interactive]
		> TimerAdder -i
		# Start entering hours and minutes in any of those format 00:00,0:00,0:0,00:0 and confirm with <enter>
		# for example
		> 10:20
		> 5:10
		# when you are done just press <enter> without anything else on the line
		# next your result will show up, giving you the totals in hours, minutes and seconds
		> Totals
		> In Hours: 15.5 # 15.5 hours means 15h and 30min and not 50min !
		> In Minutes: 930
		> In Seconds: 55800

**Parsing Mode**

		#> TimeAdder [-p|--parse[=]]
		> TimeAdder --parse=1:1,23:50,11:1,11:10
		> Totals
		> In Hours: <hours_total>
		> In Minutes: <minuets_total>
		> In Seconds: <seconds_total>
		
**File Mode**

		#> TimeAdder [-f|--file[=]]
		> TimeAdder --file="C:\Path\To\My\File.txt"
		> Totals
		> In Hours: <hours_total>
		> In Minutes: <minuets_total>
		> In Seconds: <seconds_total>
		
The file has to contain per line one `hour:time` pair. It may have superfluous whitespaces per line. Example file:

_properly formatted_
		
		4:0
		3:0
		2:30
		2:10
		0:01
		0:19
		10:20
_superfluous whitespaces but still valid_

				4:0
		3:	0
							2:30
				2:	10
				   0:01
				0:19
		10 :			20				  

# TODOs
- Since I am using the `TimeSpan` struct provided by .NET I could in theory allow values that exceed 2 digits on either side, hour or minute, since a value of say `0:180` would result in 3 hours, 180 minutes or 10800 seconds. For now the regex is set up to only recognize `dd:dd` where `d` stands for any digit between 0 and 9
- You tell me (Issues, PRs, ..)
