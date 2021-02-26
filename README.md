# YourLibrary
User can register an account or login into and borrow books from library. Also he is able to change information about him (i.e. email, phone),

If user is logged on administrator account (In login window: admin admin) he could add new books.

Included:
- XAML & WPF APP,
- relational database,
- SQLite database server,
- ORM: Entity Framework.

How to install app:
1. Download and unpack files from here: https://wseii-my.sharepoint.com/:u:/g/personal/tomasz_baran_microsoft_wsei_edu_pl/ET3u23VXdAhMgHUjsVLMLIkBMgMkG4eS6zsOOA_IQimv-Q?e=jMwK1H
2. Select RPM on: YourLibraryInstaller_1.0.4.0_x86_x64.cer and click on 'Install Certificate'
3. Choose 'Local Machine' -> Next
4. Click on: 'Place all certificates in the following store' and  'Browse'
5. Choose 'Trusted Root Certification Authorities'
6. Click 'Next' and 'Finish'
7. After added certificate click on YourLibraryInstaller_1.0.4.0_x86_x64.msixbundle and Install
Now you can open YourLibrary app, but you must run it as Administrator.

Flow:
1. Login into account- if you already don't have an account register new one (REMEMBER: you can login on administrator account),
2. If you are correctly logged on account, hidden grid will appear,
3. Now you can:
  - edit information about you
  - delete your account,
  - borrow and return books.
4. After that click on 'Log out' and app will close.
