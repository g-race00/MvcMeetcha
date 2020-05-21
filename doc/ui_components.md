# Public Site

## Top Bar

For all pages.

- Meetcha logo
- "Hello, username"
- Start a new group link
- Explore link (all groups link) (after logged in)
- Profile link (after logged in)
- Logout button (after logged in)
- Login link (before login)
- Sign up link (before login)

## Footer

For all pages.

- Your account
  - Sign up link (before login)
  - Login link (before login)
  - Profile link (after logged in)
  - Logout button (after logged in)
- Discover
  - Groups link
  - Meetups link
- Meetcha
  - About link
- Copyright

## Home Page

Before logged in only.

- Banner
  - Call for action
  - "Join Meetcha" sign up link
- List of next 5 meetups
- List of next 5 groups
- List of next 5 group types
- How Meetcha works
  - "Join Meetcha" sign up link
  - Start a new group link

## Login Page

Before login only.

- Username input
- Password input
- Login button

Redirect to all groups page after logged in.

## Sign Up Page

Before login only.

- Username input
- Email address input
- Password input
- Confirm password input
- Sign up button

Redirect to login page after sign up successfully.

## List All Group Types Page

- List of group types
  - Group type name

## List All Groups Page

- Common components
  - Navbar
    - All groups link
    - My groups link (after logged in)
    - All meetups link
    - My meetups link (after logged in)
  - Banner
    - Page title
  - Search bar
- List of groups
  - Group image
  - Group name
  - Group type
  - Group member count
  - Role (none, committee member, ordinary member)
- Page selector

## List My Groups Page

Same as all groups page, but showing only group with current member as a committee member or ordinary member.

## View Group Page

- Common components
  - Group image
  - Group name
  - Group type
  - Group member count
  - Member's role (none, ordinary member, committee member)
  - Navbar
    - About link
    - Meetups link
    - Members link
    - Comments link
    - Join group button (if is not committee member and ordinary member)
    - Leave group button (if is committee member or ordinary member)
    - Leave committee button (if is committee member)
    - Edit group link (if is committee member)
    - Delete group button (if is committee member)
- Description
- List of 5 upcoming meetups (See all link)
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup name
  - Meetup type
  - Meetup venue
  - Meetup fee
  - Meetup status (normal or cancelled)
  - Attendee count
  - Truncated description
  - View link
- List of 1 past meetups (See all link)
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup name
  - Meetup type
  - Meetup venue
  - Meetup fee
  - Attendee count
  - View link
- List of 3 most recent comments (See all link)
  - Commenter name
  - Comment date and time
  - Comment content
- List of 1 committee member (See all link)
  - Member name
- List of 10 ordinary members (See all link)
  - Member name

## List Group Meetups Page

- Common components (same as view group page)
- New meetup link (if is committee member)
- Navbar
  - Upcoming link
  - Past link
- List of upcoming meetups
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup name
  - Meetup type
  - Meetup venue
  - Meetup fee
  - Meetup status
  - Attendee count
  - View link
- Page selector

## List Group Past Meetups Page

Same as view group meetups page, except that it shows list of past meetups.

## List Group Members Page

- Common components (same as view group page)
- Navbar
  - All members link
  - Committee members link
- Search input
- List of members
  - Member name
  - Joined date
  - Role (ordinary member or committee member)
  - Add to committee button (if is committee member and that member is not in committee)
- Page selector

## List Group Committee Members Page

Same as View group members page, except that it has no search input.

## List Group Comments Page

- Common components (same as view group page)
- Comment input
- Send button
- List of comments
  - Commenter name
  - Comment date and time
  - Comment content
- Page selector

## Create Group Page

- Group name input
- Group type input
- Group image input
- Group description
- Create button

## Edit Group Page

(Committee member only)

- Group image preview
- Group image input
- Group description
- Save button

## List All Meetups Page

- Common components (same as list all groups page)
- Navbar
  - Upcoming link
  - Past link
- List of meetups
  - Meetup name
  - Meetup type
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup venue
  - Meetup fee
  - Meetup host
  - Attendee count
  - Role (None, Host, Attendee)
- Page selector

## List My Meetups Page

Same as all meetups page, but showing only meetup with current member as a committee member or attendee.

## View Meetup Page

- Attend button (if not attending) (will also join this group automatically)
- Not going button (if attending)
- Cancel meetup button (if is meetup host)
- Meetup name
- Meetup type
- Meetup date
- Meetup start time
- Meetup end time
- Meetup status
- Meetup venue
- Meetup fee
- Meetup host
- Meetup image
- Meetup description
- List of 10 attendees (See all link)
  - Member name
- Comment input
- Send button
- List of 10 comments (See all link)
  - Commenter name
  - Comment date and time
  - Comment content

## List Meetup Attendees Page

- Meetup basic info
  - Meetup name
  - Meetup type
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup venue
  - Meetup fee
  - Meetup host
- List of attendees
  - Member name
- Page selector

## List Meetup Comments Page

- Meetup basic info (same as list meetup attendees page)
- Comment input
- Send button
- List of comments
  - Commenter name
  - Comment date and time
  - Comment content
- Page selector

## Create Meetup Page

(Committee member only)

- Meetup name input
- Meetup type input
- Meetup date input
- Meetup start time input
- Meetup end time input
- Meetup venue input
- Meetup fee input
- Meetup image input
- Meetup description input
- Create button

## Edit Meetup Page

(Host only)

- Meetup name input
- Meetup type input
- Meetup date input
- Meetup start time input
- Meetup end time input
- Meetup venue input
- Meetup fee input
- Meetup image preview
- Meetup image input
- Meetup description input
- Save button

## View Profile Page

- Username
- Email address
- Edit profile link
- Edit password link

## Edit Profile Page

- Username
- Email address input
- Save button

## Edit Profile Password Page

- Old password input
- New password input
- Confirm password input
- Submit button

## About Page

Blah blah blah


# Back Office Site

## Sidebar

For all back office pages.

- Username
- Email
- Profile link
- Logout button

- Dashboard link
- Admins link
- Users link
- Groups link
- Meetups link

## Login Page

Before login only.

- Username input
- Password input
- Login button

Redirect to back office / dashboard page after logged in.

## List Admins Page

- Create admin link
- Search input
- List of admins
  - Admin ID
  - Username
  - Email address
  - View link
  - Edit link
  - Delete button
- Page selector

## View Admin Page

- Admin ID
- Username
- Email address
- Edit link
- Delete button

## Create Admin Page

- Username input
- Email address input
- Password input
- Create button

## Edit Admin Page

- Admin ID
- Username
- Email address input
- Password input
- Save button

## List Users Page

- Create member link
- Search input
- List of users
  - Member ID
  - Username
  - Email address
  - View link
  - Edit link
  - Delete button
- Page selector

## View Member Page

- Member ID
- Username
- Email address
- Edit link
- Delete button

- List member groups link
- List member meetups link

## List Member Groups Page

- Member ID
- Username

- Add member to group link
- Search input
- List of groups
  - Group ID
  - Group name
  - Group type
  - Group member count
  - Member role
  - Member joined date
  - View group link
  - Add to committee button
  - Remove from committee button
  - Leave group button
- Page selector

## Add Member to Group Page

- Member ID input
- Group ID input
- Role input
- Submit button

## List Member Meetups Page

- Member ID
- Username

- Add member to meetup link
- Search input
- List of meetups
  - Meetup ID
  - Meetup name
  - Meetup type
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup venue
  - Meetup fee
  - Meetup status
  - Meetup host
  - Attendee count
  - View meetup link
  - Leave meetup button
- Page selector

## Add Member to Meetup Page

- Member ID input
- Meetup ID input
- Submit button

## Create Member Page

- Username input
- Email address input
- Password input
- Create button

## Edit Member Page

- Member ID
- Username
- Email address input
- Password input
- Save button

## List Group Types Page

- List of group types
  - Group type ID
  - Group type name

## List Groups Page

- Create group link
- Search input
- List of groups
  - Group ID
  - Group name
  - Group type
  - Group member count
  - View link
  - Edit link
  - Delete button
- Page selector

## View Group Page

- Group ID
- Group name
- Group type
- Group image
- Group description
- Group member count
- Edit link
- Delete button

- List group meetups link
- List group members link
- List group comments link

## List Group Meetups Page

- Group ID
- Group name

- Create meetup link
- Search input
- List of meetups
  - Meetup ID
  - Meetup name
  - Meetup type
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup venue
  - Meetup fee
  - Meetup status
  - Meetup host
  - Attendee count
  - View meetup link
- Page selector

## List Group Members Page

- Group ID
- Group name

- Search input
- List of members
  - Member ID
  - Username
  - Email address
  - View link
  - Leave group button
- Page selector

## List Group Comments Page

- Group ID
- Group name

- Search input
- List of comments
  - Comment ID
  - Commenter ID
  - Commenter name
  - Comment date and time
  - Comment content
  - Delete button
- Page selector

## Create Group Page

- Group image input
- Group name input
- Group description
- Create button

## Edit Group Page

- Group ID
- Group name input
- Group type input
- Group image input
- Group image preview
- Group description
- Save button

## List Meetup Types Page

- List of meetup types
  - Meetup type ID
  - Meetup type name

## List Meetups Page

- Create meetup link
- Search input
- List of meetups
  - Meetup ID
  - Meetup name
  - Group ID
  - Group name
  - Meetup type
  - Meetup date
  - Meetup start time
  - Meetup end time
  - Meetup venue
  - Meetup fee
  - Meetup status
  - Meetup host
  - Attendee count
  - View link
  - Edit link
  - Delete button
- Page selector

## View Meetup Page

- Meetup ID
- Meetup name
- Group ID
- Group name
- Meetup type
- Meetup date
- Meetup start time
- Meetup end time
- Meetup venue
- Meetup fee
- Meetup status
- Meetup host
- Attendee count
- Meetup image
- Meetup description
- Edit link
- Delete button

- List meetup attendees link
- List meetup comments link

## List Meetup Attendees Page

- Meetup ID
- Meetup name

- Search input
- List of members
  - Member ID
  - Username
  - Email address
  - View link
  - Not going button
- Page selector

## List Meetup Comments Page

- Meetup ID
- Meetup name

- Search input
- List of comments
  - Comment ID
  - Commenter ID
  - Commenter name
  - Comment date and time
  - Comment content
  - Delete button
- Page selector

## Create Meetup Page

- Meetup name input
- Group ID input
- Meetup type input
- Meetup date input
- Meetup start time input
- Meetup end time input
- Meetup venue input
- Meetup fee input
- Meetup status input
- Meetup host ID input
- Meetup image input
- Meetup description input
- Create button

## Edit Meetup Page

- Meetup ID
- Meetup name input
- Group ID input
- Meetup type input
- Meetup date input
- Meetup start time input
- Meetup end time input
- Meetup venue input
- Meetup fee input
- Meetup status input
- Meetup host ID input
- Meetup image preview
- Meetup image input
- Meetup description input
- Save button

## View Profile Page

- Admin ID
- Username
- Email address
- Edit profile link
- Edit password link

## Edit Profile Page

- Admin ID
- Username
- Email address input
- Save button

## Edit Profile Password Page

- Old password input
- New password input
- Confirm password input
- Submit button
