.. |br2| raw:: html

   <br /><br />

.. |br| raw:: html

   <br />


===================
Expression Wrinkles
===================

Activating Expression Wrinkles in Character Creator
===================================================

The 'Expression Wrinkles' system in Character Creator was introduced in CC4 version 4.2.  It can be easily activated for any applicable character (any CC3+ or above character).  Expression wrinkles cannot be activated for simplified character models like GameBase or ActorCore.

+ Either create a new CC3+ or above character or open an existing project.

.. |button| image:: images/cc-expression-wrinkle-tab-button.png

+ Navigate to the *Modify Pane* and select the *Expression Wrinkles Tab*.  Please note that the expression wrinkles tab will only be available for valid characters. |button|

+ Check the 'Activate Expression Wrinkles' box to enable wrinkle support for the current character.  *This box must be checked prior to export of the character, so that the Unity or Blender add-ons can correctly process and utilize the wrinkle system*.

.. image:: images/cc-expression-wrinkle-tab-content.png
    :align: center

|

+ The expression wrinkle system should now be active and any expression changes made by the character should drive the blending of wrinkles onto the skin texture.

.. Tip:: 
    In order to utilize the expression wrinkle system in Unity or Blender, you **must** first activate the system (as above) in Character Creator and then (re)export the character for the chosen platform.

    The system cannot be retrospectively activated for existing Unity or Blender exports since it relies on a new set of textures and masks that will be absent from prior exports (they are also absent from exports made where the expression wrinkle system is inactive). 


Expression Wrinkles in Blender
==============================

The expression wrinkle system is available in Blender starting with version 1.5.4 of the CC/iC Blender Tools add-on.  Exports from Character Creator with the 'Expression Wrinkle' system active (see above) can be imported into Blender with the :ref:`Standard Import` procedure and the wrinkle effects will be automatically added with no further user intervention being required.

.. figure:: images/blender-imported-wrinkles.png
    :align: center
    :width: 600
    
    *Imported Expression Wrinkles*

Should you wish to disable the 'Expression Wrinkles' feature, then this can be done in the :ref:`Build Prefs` section of the Build settings panel (please follow the link for more details). 

.. Warning::
    **Adding extra texture samplers to the shader (Advanced Users Only).**

    Please note that the Eevee renderer has a hard limit of 32 texture samplers. Eevee itself will allocate itself 8 of them - on some hardware (Nvidia RTX) those 8 are also available to the shader; on other hardware (AMD Radeon) the 8 samplers *may* be unavailable.

    The shader that deals with the wrinkle expression system uses 23 texture samplers so depending on the platform, any additional user added texture samplers *may* exceed the gl_MaxTextureImageUnits limit and cause shader compilation to fail (and turn pink).

