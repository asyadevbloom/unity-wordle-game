# 📝 Notes — Wordle game

## 🌱 what I've learned so far
- setting up a new Unity 2D project 🎮
- creating UI with TextMeshPro
- (more to come as I follow the tutorial)

## 😅 what was hard
- mothing yet — just getting started!

## 💡 what I want to remember
- nothing yet

## 🌸 ideas for the future
- add a hint system
- dark mode theme
- exit button

## 🎯 progress
- [x] create Unity project
- [x] create GitHub repository
- [ ] follow tutorial — in progress
- [ ] 
- [ ] add en exit button

## 🎶 just thoughts
- it's finally a new version of Unity 6.6, so i'll try this project with it
- it's more common to choose 'scale with screen size' in the canvas scaler
- reference resolution for a tablet is '1280x720' (horizontal) or '720x1280' (vertical). 1920x1080 is good for a laptop
- in a horizontal layout group: small spacing is 4 pixels, medium is 8, and large is 16. this is common in ui design
- the standard amount of rows in a wordle game is 6
- outline is for setting the outline, obviously
- to use fonts in textmeshpro, you need to create a font asset for each font in SDF format

- i didn't know about is, but there is a 2248 game, it's something different from 2048
- old version of input system:
<img width="853" height="806" alt="image" src="https://github.com/user-attachments/assets/ec00cabc-dc42-480d-bef8-2fa91fac1c5e" />

- rewrote it using the new version:
<img width="808" height="582" alt="image" src="https://github.com/user-attachments/assets/a5f4cb82-116f-4049-be09-d33c22cc5040" />

- tried to debug for the first time, i guess:
<img width="846" height="45" alt="image" src="https://github.com/user-attachments/assets/4d9e3cfd-ca99-4b4b-80fd-8ac54dae78df" />

- Ctrl + K, then Ctrl + D - formats the entire file according to standard formatting rules
- Mathf.Clamp() is a function that limits a number to a specific range. if the number goes outside the range, it gets "clamped" to the nearest boundary.
Mathf.Clamp(value, min, max), where value is the number you want to limit, and max and min are the maximum and minimum allowed values
or you can use functions Max() and Min(), but their combination is Clamp()
- i decided to comment out the lines with the old version of Input for greater clarity

- for Enter in the new Input System, there are two keys: the regular Enter and the Enter on the numeric keypad (Numpad), it's better to use both, so the game works on any keyboard:
<img width="1038" height="115" alt="image" src="https://github.com/user-attachments/assets/f1132c50-eab3-488a-85e3-1583d93b6fd3" />

- how to work with resources format txt for example:
<img width="701" height="50" alt="image" src="https://github.com/user-attachments/assets/33482f47-1e62-493f-b6a1-edebc2006d4a" />

- this line takes the text from the loaded file and splits it into an array, it splits by the newline character '\n', so each line in the file becomes one element in the array
<img width="273" height="32" alt="image" src="https://github.com/user-attachments/assets/51785f95-6eb1-429e-b8e5-feb51ba578db" />

- we can switch to debug and see what's happening when we start the game:
<img width="1604" height="320" alt="image" src="https://github.com/user-attachments/assets/f266c997-edce-453d-806d-37d2a990ff4a" />

- Random.Range() is a function that returns a random number within a specified range. there are two versions of this function, and they behave differently depending on the type of numbers you give it. the integer version and the float version. the integer version excludes the maximum value
- Trim() is a string method that removes whitespace characters from the beginning and the end of a string, it doesn't remove spaces in the middle
- Contains() is a string method that checks if a string contains a specific character or substring, it returns true or false. it cares about uppercase and lowercase letters. but if it is used on a List or array, it works differently - it checks if the entire element matches, not just a substring
- when the script is disabled, update will not be called
- { get; private set; } the property is readable by anyone (other scripts can see it), anyone can read it, but only this script can change it

- [System.Serializable] and [Header("States")] are attributes that help organize and store data. the first one makes your custom class visible in the Unity Inspector so you can edit its values, the second one adds a bold title "States" above the field in the Inspector

<img width="323" height="192" alt="image" src="https://github.com/user-attachments/assets/d0df701f-db87-4247-aeaa-2487d68a6fa4" />
<img width="353" height="232" alt="image" src="https://github.com/user-attachments/assets/4d8ab946-95e7-4ed2-8f2a-15b9a76d73ca" />
<img width="460" height="277" alt="image" src="https://github.com/user-attachments/assets/24921283-386e-4913-a50e-5ca03bf1b3e5" />
