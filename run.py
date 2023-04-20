import os
import subprocess
import re

file1 = open("unit_test_output.txt", "r")
file2 = open("result.txt", "w")

file2.write("Passed")
file2.close()

for line in file1:
    if "Failed" in line:
        file2 = open("result.txt", "w")
        file2.write("Failed")
        file2.close()
        quit()