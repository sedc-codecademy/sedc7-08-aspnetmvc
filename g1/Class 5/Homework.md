# Homework - Contacts App

## Description
Our client demands a simple contacts app with a few functionalities for his personal needs, so we happen to be the only ones available in the whole team to make that app. So let's see what he wrote on the requirements papers:  
* I should be able to list all my contacts in the "database"(we will simulate one with a static list of contacts)
* I also want to be able to list all my closest friends
* I should be able to add a new contact to the already existing list

## Technical Description
So those are typical client's requirements, not very clear on where and what to start huh?  
Luckily we have our Team Leader to help us with that, so he did:
* There should be 1 model, could be named "Contact", it should contain:  
    - **First Name**
    - **Last Name**
    - **Is Close Friend**
    - **Phone Number**
* There should be one controller named **CoolController**, it's route should be: *"/contacts"*. This controller should have a few actions:  
**Note:** try to re-use views
    - An action to get all contacts, named **GetEveryone** with route:  *"/getallcontacts"*
    - An action to get all closest friends, named **GetFriends** with route: *"/getclosestcontacts"*
    - An action to add a contact to the contacts list, named **AddContact**  
    **Note:** This one should be **POST** method
    - An action of the same name as previous, only a **GET** method with a purpose to render(get) the view of the form to fill information  
* We want to surprse our client and as a bonus we want give him one more feature, a good old validation on the form
    - All fields should be required
    - The user should only be able to enter name and last name not longer than 25 characters nor shorter than 3 characters
    - The phone number should be a range from 9 to 11 digits

**NOTE 1:** You can instantiate the list of contacts in the **CoolController**, or you can create a static class named for ex. ContactsDatabase and define a static property ContactsList  
**NOTE 2:** Example on how to call GetEveryone action in CoolController: */contacts/getallcontacts*