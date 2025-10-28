# Physics Engine 2D (Thesis Project)

#### Overview
A 2D physics engine written in C# and WPF.

The project simulates real-time physical interactions between objects using custom implementations of motion integration, collision detection, and collision response. It was created as part of a thesis exploring the internal workings of physics systems in games and simulations.

<img width="1066" height="753" alt="image" src="https://github.com/user-attachments/assets/2eb8b3c7-0326-4c10-adbd-5559c64c37b6" />

<br>


#### Features

- Real-time object movement and collisions

- Custom force and gravity handling

- Elastic and inelastic collision response

- Simple visual interface using WPF

<br>


#### Controls

###### :arrow_forward: Buttons

- Start Time/Stop Time — toggle current simulation

- Pick Scene — pick scene to generate new physics scenario

- Generate — clear scene and generate new scene using currently selected scene

<br>


###### :clapper: Scenes

- Ambient — small amount of different physics objects with random velocity and position

- Brownian Motion — one massive object and many smaller objects

- Resting Contact — test scene meant to evaluate when physics objects become or remain asleep

- Billiard Sample

- Tunneling — test scene meant to check under which circumstances physics engines may encounter the concept of tunneling

- Marginal Bounds — test scene meant to evaluate under which circumstances physics engines may encounter issues when applying position correction

- Gravity — test scene to evaluate gravity and timesteps alone

- Energy Conservation — test scene meant to evaluate if objects exchange energy on contact

- Large Set — scene with over 1600 physics objects

<br>

###### :gear: Settings

- Gravity — adjust global gravity using both x and y axis

- Timestep — adjust the time of the simulation frequency

- Default Contact Offset — adjust additional distance at which objects are being separated during contact

- Velocity Threshold — adjust minimal relative linear velocity at which collisions are treated as inelastic

- Linear Sleep Tolerance — adjust minimal velocity value at which physics objects will remain asleep or go to sleep.

<br>

#### Technologies Used
- C# / .NET 6
- Windows Presentation Foundation (WPF)
