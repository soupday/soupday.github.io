~~~~~~~~~~~~~~~~
TLDR Quick Usage
~~~~~~~~~~~~~~~~

Export from Character Creator / iClone
======================================

Create your character in Character Creator or iClone and export it using the 'Unity' option.

Import into Unity
=================

Drag all the exported files into your Unity (HDRP/URP: 2020.3+, 3D: 2019.4.11f1) project.


Process the Character
=====================

Open the tool window via right clicking on the fbx file or use the top menu (Reallusion -> Import Character)

In the tool window click on the character you want to process (make sure it's name is the one shown at the top).  Then click 'Build Materials' and wait while Unity processes the character and sets it up.  If it looks weird, wait for any shaders to compile (progress bar at bottom right).  If its the 3D render pipeline version make sure the :ref:`color space<Considerations for the URP and 3D Render Pipeline>` is set to 'linear'.  Also if 3D or URP are used, the install the post processing package from the Unity Registry for further enhancement (see the above linked section for install details).


Thats it
========

You're all done.  Drag the character into your scene and do your thing.


TLDR Usage Video
================

.. youtube:: 6VIH5eXCioQ

| 

