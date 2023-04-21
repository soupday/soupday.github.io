.. _HDRI: https://en.wikipedia.org/wiki/High-dynamic-range_imaging

.. _Preview Range: https://docs.blender.org/manual/en/latest/editors/graph_editor/introduction.html#graph-preview-range

.. _Point Cache: https://code.blender.org/2011/01/a-look-at-point-cache/

~~~~~~~~~~~~~
 Scene Tools
~~~~~~~~~~~~~

**Scene Tools** are a simple set of tools which allow the rapid manipulation of some scene conditions.  The scene tools are available in both tabs of the add-on and are located at the very bottom of each.

  .. image:: images/scene_tools_panel.jpg

Scene Lighting
==============

*Scene Lighting* provides a simple means of quickly applying a variety of lighting and `HDRI`_ presets.  Including a close approximation of the lighting used in Character Creator for reference purposes.

*3 Point Tracking and Camera* instantiates a camera and a transform point which the camera will track.

..
    *Animation Range from Character* sets the animation frame range to that of the current action on the character's armature.

    *Sync Physics Range* sets the physics bake range to the current world scene frame range.


Simulation Baking (Point Cache)
===============================

A number of easily accessible timeline and physics baking tools have been provided as part of the Scene Tools in the CC/iC Pipeline tab of the add-on:

   .. figure:: images/bl-timeline-phys-pane.png
      :align: center

      *Timeline and physics baking tools*

**Animation Range** - The range of the animation can be quickly manipulated here. Two distinct frame range functions are available:

.. |prev| image:: images/bl-timeline-phys-prev.png

.. |exp| image:: images/bl-timeline-phys-exp.png

.. |fit| image:: images/bl-timeline-phys-fit.png

- **Use Preview Range** |prev| - This will activate the *Viewport Preview Range*. This can be set in the timeline window, for more details see the `Preview Range`_ section of the official Blender documentation.

- **Expand Animation Range** |exp| - This tool is used to increase the scene animation frame range to the frame range of the current action on the character (it will never decrease the frame range).

- **Fit Animation Range** |fit| - This tool will always match the scene frame range to the frame range of the current action on the character.

**Physics Cache** - Several tools are provided to allow quick access to the physics baking functions for Cloth Physics and Spring Physics. The frame ranges can also be reset so the  physics simulations match the intended frame range of the scene you are preparing (a common cause of a physics simulation not working is that its frame range is incorrectly set).

The common features are as follows:

.. |reset| image:: images/bl-timeline-phys-reset.png

.. |bake| image:: images/bl-timeline-phys-bake.png

.. |free| image:: images/bl-timeline-phys-free.png

- **Reset** |reset|

   - **Cloth Physics** - Resets the physics point cache on all cloth objects and synchronizes the physics point cache ranges on all cloth objects to fit the current scene animation range. i.e. If the point cache frame range does not cover the current scene range (or preview range) it will be extended to fit.
        
   - **Spring Physics** - Resets the physics point cache for the rigid body world and synchronizes the physics point cache range to fit the current scene animation range. i.e. If the point cache frame range does not cover the current scene range (or preview range) it will be extended to fit.

- **Bake** |bake| - This will bake the physics simulation to Blender's point cache.

   - **Cloth Physics** - This will bake the simulation for the currently **selected** cloth object.

   - **Spring Physics** - This will bake the simulation for all spring bones. 

- **Free** |free| - This will clear the point cache.

The Reset/Bake/Free functions are also able to be performed all at once (*caveat emptor*) in the 'All dynamics' section. The most useful function here is 'Free All Dynamics' which will clear the point cache for all cloth and spring objects at the same time.
 
For further details of Blender's cache system, please see these developer notes on the `Point Cache`_.
