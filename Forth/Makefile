
test : factorial.fs
	sed -n -e 's/\(<- \)\(.*\)/\2/pw input.dat'     test.txt >/dev/null
	sed -n -e 's/\(-> \)\(.*\)/\2/pw expected.dat' test.txt >/dev/null
	gforth factorial.fs <input.dat >result.dat
	diff expected.dat result.dat

clean : 
	rm *.dat
