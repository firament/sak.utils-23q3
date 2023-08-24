# CsvSlicer

## Specs
- First one line will be header, to be repeated in all slices
- Parameters
  - Input file name, string
  - Slice size, integer, nummer of rows without any formatting
  - Header row count, integer, default = 1

## Dependencies
1. Newtonsoft.Json
2. NLog


## Environment

### git
- Set username and email, required for commits and pushes
	```sh
	git config user.name "John Doe"
	git config user.email johndoe@example.com
	```
- Set consistent `LF` line endings
	- on Windows machine, scripts copied to Linux images fail to run due ot `CRLF` endings
	- https://gist.github.com/ajdruff/16427061a41ca8c08c05992a6c74f59e
	- Ensure `LF` in filesystem and git repository
		```sh
		# Check
		git config --get core.eol
		git config --get core.autocrlf
		# Set
		git config core.eol lf
		git config core.autocrlf false
		```
	- Set this before creating file. Or open, edit and save files again to apply line endings properly.
