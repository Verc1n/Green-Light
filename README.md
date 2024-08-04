# Green Light

Author: Ryan Hermans <br/>
Created on: 27/6/2024 <br/>
Released on: 4/8/2024 <br/> <br/>

This program is an app to allow learner drivers to record their drives and track their progress. <br/>
It allows them to view their previously recorded drives. <br/><br/>

**Modification of Design**<br/>
The original project plan was far too ambitious for a variety of reasons, and needed to be cut down significantly.
Two major sources of problems were that this was the first project of any sort of scale I had attempted, and thus did not really have a good grasp of how long things took, and that I had decided to use a new framework for development, meaning a large portion of the development time was dedicated to learning fundamental aspects of the framework and troubleshooting features. This factor also contributed to the difficulty in making an accurate plan with a reasonable scope. <br/> <br/>

My initial development strategy was to start by building up some basic user interfaces for each page, though not as yet connected to any actual functionality, then to construct the basic infrastructure required by the solution (models, classes, database connection), and finally to implement the specific functionalities required by each page and connect the code-behind to each page. The benefit of this approach was that it ensured a seperation between code-behind and user interface, a desirable property both for portability and for ensuring the quality of the code, but the downside of this was that it took a long time before even a basic feature like recording a drive would be implemented. <br/><br/>

As a consequence, towards the end of the project it became apparent that I would not be able to meet much of the requirements. The most obvious first point of call would be to cut out extra pages such as the statistics page, which was not material to the core functionality of the solution but required a lot of work. The focus then shifted to getting the minimum viable product completed - namely recording and saving a drive, and interacting with a database to ensure data is saved between sessions. Because of some earlier good design decisions and infrastructure, such as adhering to the model-view-viewmodel structure and constructing the database out of classes, this functionality was relatively simple to implement. While there was also functionality to add conditions to a drive, and this was already almost completely funcitonal, it was taking too long to complete and had to be cut.<br/> <br/>

With a minimum viable product secured, every other functionality was a bonus - such as a login or drive conditions. Rather, I instead focussed my attention on the other aspects of development - namely internal documentation and testing. Finally, the evaluation criteria also have to be adjusted to reflect the changed product. The original criteria were: <br/><br/>
**Efficiency Criteria**<br/>
1.	The user should be able to start recording a drive within 5 seconds of pressing the app icon. <br/>
2.	The user should have their login saved while they are using the app (should not have to log in more than once per session).<br/>
3.	The user should be able to record all relevant conditions and have it saved to the drive in under 30 seconds.<br/>
4.	The user should have their recommended driving conditions displayed immediately upon opening the app.<br/>
5.	The time taken to open the database should not be noticed by the user when searching, sorting or submitting drives.<br/>
 
**Effectiveness Criteria** <br/>
1.	The solution should provide additional conditions to measure their driving with, allowing them to better judge what they need to learn.<br/>
2.	The solution should provide better summary statistics than MyLearners  in order to give the learner direction.<br/>
3.	The supervisor should be able to add a manual drive without going to an external page.<br/>
4.	A user who is unfamiliar with the app should be able to navigate to every page without getting confused.<br/>
5.	The solution should not produce any incorrect information.<br/>
6.	A user should be able to understand the summary statistics and recommendations.<br/>
7.	The solution has appropriate error messages when a function is not working as intended, or when the user has made an invalid input.<br/>
8.	The solution should place restrictions on the user where possible so as to ensure that they cannot make an invalid input.<br/>
9.	The size of the text should be changeable to aid users with poorer vision, without breaking the UI.<br/>
10.	The recommended driving conditions should be relevant to the user.<br/><br/>

Of these, efficiency criteria 2 and 3 and effectiveness criteria 2,3,6 and 9 had to be removed and some other criteria had to be slightly reworded. Some extra criteria were also added to make up for the changes. The adjusted criteria look like:<br/><br/>

**Efficiency Criteria**<br/>
1.	The user should be able to start recording a drive within 5 seconds of pressing the app icon. <br/>
2.	The user should have their recommended driving conditions displayed immediately upon opening the app.<br/>
3.	The time taken to open the database should not be noticed by the user.<br/>
4. The user should not notice any lag/loading between or inside pages. <br/>
 
**Effectiveness Criteria** <br/>
1.	The solution should provide additional conditions to measure their driving with, allowing them to better judge what they need to learn.<br/>
2.	A user who is unfamiliar with the app should be able to navigate to every page without getting confused.<br/>
3.	The solution should not produce any incorrect information.<br/>
4.	The solution has appropriate error messages when a function is not working as intended, or when the user has made an invalid input.<br/>
5.	The solution should place restrictions on the user where possible so as to ensure that they cannot make an invalid input.<br/>
6.	The recommended driving conditions should be relevant to the user.<br/>
7. The solution should allow users to start, pause and resume a timer to track their drive. <br/><br/>

**Testing Techniques**<br/>
To formally test the solution, I constructed an excel table with the columns: <br/>
What is to be Tested<br/>
Test Data Input<br/>
Expected Result<br/>
Actual Result<br/>
Changes Made<br/>
Other Notes<br/>
These tests tried different paths that the user could take through the solution, as well as the different inputs they could make. As a general design principle, in a mobile app it is preferable to not require users to type wherever possible, as this is a slow action, and as such the majority of possible text input boxes were replaced with components such as drop downs and buttons. As a consequence, the user's possible inputs are actually fairly limited, and thus require little additional validation, and consequently little additional testing for that validation.
