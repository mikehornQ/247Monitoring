import sys 
import string
import os 
import re 
 
if __name__ == "__main__":
    
    input_file = open(os.path.abspath(sys.argv[1]),  'rb',  0)
    found_str = "QM:(.*?)/QM"
    
    for line in input_file:
        filtered_string = filter(lambda x: x in string.printable, line)                
        matches = re.findall(found_str, filtered_string, 0)
        for match in matches:  
            print(match)
            extracted = re.search("(.*)=(?:(?!.\n).)*", match)                            
            print extracted
            