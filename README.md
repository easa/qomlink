# qomlink
### Objective
This app was used to login / logout to the network of dorm of Qom university in an easy way.
It's based on sending login request with multiple username and password that change frequently, and for multiple ip servers that was used in many dorms.

### Functionality
It's a Windows console app working with .net2 or higher.

### Structure
The main job is doing in service layer and there are two other layer model and interface.
service will take care of all main jobs like sending requests, model will work with information and interface is using service functions to show what is happening to user and get the command from him.
