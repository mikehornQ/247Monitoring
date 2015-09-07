'''
Created on 18 May 2015

@author: Mike
'''
from    forecastAPI import Forecast, TestRunParameters, TestRunner
import  sys, os, inspect, re, string, time
from    datetime import timedelta
import  csv
import  os.path
    
if __name__ == "__main__":

    debugMode = False
# Create and initialise an INSTANCE OF Forecast

    forecast = Forecast()

    forecast.initialise()
	
    # Create a TestRunParameters Object that contains the details of the test to execute. 
    
    #Parameters are read in from the command line.   
    testRunParameters = TestRunParameters(workspace = sys.argv[1], project = sys.argv[2], test = sys.argv[3], series = sys.argv[4])

    # Create a TestRunner Object
    testRunner = forecast.createTestRunner(testRunParameters)

    # Label start of output from script   
    if debugMode == True: 
        print
        print "\r\n---------- Start of output from %s ----------\r\n" % (os.path.basename(sys.argv[0]))

        # Print out test run details to the command line
        print "%s (%s): %s: %s" % (os.path.basename(sys.argv[0]), inspect.getlineno(inspect.currentframe()) , 'WORKSPACE', sys.argv[1])
        print "%s (%s): %s: %s" % (os.path.basename(sys.argv[0]), inspect.getlineno(inspect.currentframe()) , 'PROJECT', sys.argv[2])
        print "%s (%s): %s: %s" % (os.path.basename(sys.argv[0]), inspect.getlineno(inspect.currentframe()) , 'TEST', sys.argv[3])
        print "%s (%s): %s: %s" % (os.path.basename(sys.argv[0]), inspect.getlineno(inspect.currentframe()) , 'SERIES', sys.argv[4])
        print "%s (%s): %s: %s" % (os.path.basename(sys.argv[0]), inspect.getlineno(inspect.currentframe()) , 'RUN NUMBER', testRunner.getRunNumber())
        print "%s (%s): %s: %s" % (os.path.basename(sys.argv[0]), inspect.getlineno(inspect.currentframe()) , 'RUN PATH', testRunner.getRunPath())
        print "\r\n----------- End of output from %s -----------\r\n" % (os.path.basename(sys.argv[0]))
        
    eventlogfile = testRunner.getRunPath() + "\\localhost\\intel.win32.clr4_5.0\\scratch\\QMmetrics.txt"
    historyfile = os.getcwd() + "\\QMmetrics.csv"
		
    if debugMode == True:
        print "%s" % (time.strftime("%c"))
        print "Event log file: %s\r" % (eventlogfile)
            
    os.environ["EPPLOGFILE"] = eventlogfile

    # Start the test. If the test has NOT completed within 1 hour, then abort

    if not testRunner.start(timedelta(hours=1).seconds):

        # Some errors occurred during the test run. Look at the test output for more details

        print 'ERRORS OCCURRED'
        sys.exit(1)
    
    # Test completed successfully
    rownum = 0
    errcount = 0
    f = open(eventlogfile, 'rb') # opens the current metric file for reading	
    j = open(historyfile, 'w') # opens the saved metrics file for writing
	
    if not os.path.isfile(historyfile):
		print 'Time,Server,Metric,Threshold,Operator,Value' > j
			
    try:
        reader = csv.reader(f)  # creates the reader object
        for row in reader:   # iterates the rows of the file in orders
            
            if rownum == 0:
                header = row
            else:				
				if debugMode == True:
					print '%s %s %s' % (row[5], row[4].strip(), row[3])    # prints each row
					
				print row >> j
				
				if ((row[4].strip() == "GT" and int(row[5]) > int(row[3])) or
			       (row[4].strip() == "LT" and int(row[5]) < int(row[3])) or
				   (row[4].strip() == "GE" and int(row[5]) >= int(row[3])) or 
				   (row[4].strip() == "LE" and int(row[5]) <= int(row[3])) or 
				   (row[4].strip() == "NE" and int(row[5]) <> int(row[3])) or 
				   (row[4].strip() == "EQ" and int(row[5]) == int(row[3]))):
				   
					print 'ERROR: %s: %s threshold breached (Value: %s %s %s)' % (row[0], row[2], row[5], row[4], row[3])
					errcount += 1
                         
            rownum += 1   
    
    finally:
        f.close()      # closing
        j.close() 
	
	if errcount > 0:
		sys.exit(1)
	else:
		sys.exit(0)    
    
    
    
