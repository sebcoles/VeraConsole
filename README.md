# VeraConsole

## Commands
### getflaws 
Get all flaws for a build


## Flags
`-o outputtype (csv)`	// Default is just to print to console

`-f filename`			// Name of file to output csv results too

`--buildid	XXXXXXXX`	// Build ID of the scan

`--fixforpolicy`		// If true, results will only contain flaws that break policy (default is false)

## Get Triage Flaws view for a build for policy breaking flaws and write to csv
`.\VeraConsole.exe getflaws --buildid XXXXXXXX -o csv -f "name_of_csv" --fixforpolicy true

