#!/bin/bash
echo "Running .gitignorerm.sh ..."
foundany=0
for f in $(git check-ignore *)
do
{
	#git rm --cached $f
	if [ "$1" = "--dry-run" ];
	then {
		echo "Would delete '$f' ..."
		foundany=1
	}
	else {
		echo "Deleting '$f' ..."
		rm -rf $f
		foundany=1
	}
	fi
}
done
if [ "$foundany" -eq "0" ];
then echo "No files ignored by Git found."
fi
echo "Done running .gitignorerm.sh"

