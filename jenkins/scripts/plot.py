'''
Created on 18 Jun 2015

@author: Mike
'''


import plotly.plotly as py
from plotly.graph_objs import *

trace0 = Scatter(
    x=["one", "two", "three", "four" ],
    y=[10, 15, 13, 17]
)
trace1 = Scatter(
    x=["one", "two", "three", "four" ],
    y=[16, 5, 11, 9]
)
data = Data([trace0, trace1])
plot_url = py.plot(data, filename='first-basic-line')