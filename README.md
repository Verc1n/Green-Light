# Green Light

Author: Ryan Hermans <br/>
Created on: 27/6/2024 <br/>
Released on: 4/8/2024 <br/> <br/>

This program is an app to allow learner drivers to record their drives and track their progress. <br/>
It allows them to view their previously recorded drives. <br/>

The original project plan was far too ambitious for a variety of reasons, and needed to be cut down significantly.
Two major sources of problems were that this was the first project of any sort of scale I had attempted, and thus did not really have a good grasp of how long things took, and that I had decided to use a new framework for development, meaning a large portion of the development time was dedicated to learning fundamental aspects of the framework and troubleshooting features. This factor also contributed to the difficulty in making an accurate plan with a reasonable scope. <br/> <br/>

As a consequence, towards the end of the project it became apparent that I would not be able to meet much of the requirements. The most obvious first point of call would be to cut out extra pages such as the statistics page, which was not material to the core functionality of the solution but required a lot of work. The focus then shifted to getting the minimum viable product completed - namely recording and saving a drive, and interacting with a database to ensure data is saved between sessions. Because of some earlier good design decisions and infrastructure, such as adhering to the model-view-viewmodel structure and constructing the database out of classes, this functionality was relatively simple to implement. While there was also functionality to add conditions to a drive, and this was already almost completely funcitonal, it was taking too long to complete and had to be cut.<br/> <br/>

With a minimum viable product secured
