.. |br2| raw:: html

   <br /><br />

.. |br| raw:: html

   <br />

.. _Blender tools for Character Creator/iClone: https://github.com/soupday/cc_blender_tools/releases

.. _Alembic: https://en.wikipedia.org/wiki/Alembic_(computer_graphics)

~~~~~~~~~~~~~~~~
 Texture Baking
~~~~~~~~~~~~~~~~

.. |Bake| image:: images/new_ui_bake.png

.. |Bake_s| image:: images/new_ui_bake.png
    :width: 28

.. |BakeHair| image:: images/new_ui_bake_hair.png

.. |BakeHair_Yellow| image:: images/bake_hair_yellow.png

.. |BakeHair_s| image:: images/new_ui_bake_hair.png
    :width: 28

.. |BakeHair_Yellow_s| image:: images/bake_hair_yellow.png
    :width: 28

The texture baking process is used to create a somewhat simplified high performance version of an imported character for use in complex scenes to avoid performance issues.  This version of the character will maintain the highest possible visual quality.

The baking process will produce a separate 'Baked Prefab' which incorporates any user changes made to the materials before baking.  This can be used identically to the prefab created by building the materials normally.

Character textures (skin, eyes *etc*.) and hair textures are handled differently and are discussed in their own sections below:


Texture Baking Workflow |Bake| |BakeHair|
=========================================

.. |prev_light| image:: images/preview_lighting_model.png

Basic Baking Workflow
---------------------

Firstly ensure that the character has been correctly imported and has had its materials built according to the steps in the :ref:`Importing into Unity` section of the documentation. 

- Open the character in a :ref:`Preview Scene |preview|` (see the link for details).
- Prepare the character by making any material changes deemed necessary in the :ref:`Materials Inspector` (see the link for details)
- Should you wish to modify the hair color see the section on :ref:`Hair Recoloring |BakeHair_s|` for more details.
- These changes can be conveniently evaluated using the many lighting setups available with the |prev_light| icon, and also with the animation player and facial expression tools.

- Set the baking options from the two dropdown menus (only if needed)

.. image:: images/new_ui_bake_options.png
    :align: center

|

.. |bksh| image:: images/new_ui_bake_shaders.png

.. |bkshtxt1| replace::
    **Custom Shaders** *(Default)*  Uses materials with a custom ShaderGraph shader for very high quality and very good performance (*Hair* and *Eyes* only - *Skin* will use the default shader eg. HDRP/Lit, URP/Lit or Standard shader).

.. |bkshtxt2| replace::
    **Default Shaders** Uses the system default pbr shaders in the baked output, if performance is desired above all else, at the cost of visual quality. Hair, Eyes and Skin will all use HDRP/Lit, URP/Lit or Standard shader depending on render pipeline.

.. |bkpre| image:: images/new_ui_bake_prefab.png

.. |bkpretxt1| replace::
    **Separate Baked Prefab** *(Default)* The baked output will be written to a new prefab <name>_baked (in the same directory as the initially created prefab).

.. |bkpretxt2| replace::
    **Overwrite Prefab** This option will overwrite the initially (when the materials are built during initial processing) created prefab with new materials and textures.  
    
..
  This feature is used principally for the 'iClone Live Link'. 

.. list-table::
  :widths: 19 31
  :header-rows: 0
  
  * - |bksh|
    - |bkshtxt1|
      |br2|
      |bkshtxt2|
  * - |bkpre|
    - |bkpretxt1|
      |br2|
      |bkpretxt2|


- Once you are satisfied with the material settings and the desired options, then the process can be started with the |Bake_s| button.
- When baking is complete, a new prefab will be created in the 'Prefabs' sub-directory of the current model location as '<MODEL_NAME>_Baked.prefab'.  The materials and baked textures will be written to to the 'Baked' sub-directory (these should all be retained).

.. code-block::

  <Import Folder>
    |-- Prefabs
    |     |-- <MODEL_NAME>.prefab
    |     |-- <MODEL_NAME>_Baked.prefab
    |
    |-- Baked
    |     |-- Materials
    |     |-- Textures
    |
    |-- Animations
    |-- materials
    |-- textures
    |-- <MODEL_NAME>.fbm
    |-- <MODEL_NAME>.fbx
    |-- <MODEL_NAME>.json


.. Admonition:: Baking is the Final Step
   
   Baking represents the **final** step, since no further material changes can be made to the baked prefab.  Should you wish to update the baked prefab, then you must start the baking workflow again.

Hair Recoloring |BakeHair_s|
----------------------------

If you wish to adjust the hair color of the character, take the following steps:

- Navigate to the hair material in the :ref:`Materials Inspector` treeview: it will be listed as 'Hair_Transparency_Pbr'.

   .. figure:: images/hair_materials_treeview.png
      :align: center

      *Linked Hair Materials Selected in the Treeview*

- Selecting 'Hair_Transparency_Pbr' will *multiple select* all of the relevant materials.

- You can also manually navigate to hair materials by clicking on hair objects in the scene view window and opening up the materials in the inspector.  Please note that you will have to enable color on each material individually. 

- In the (Standard) Inspector window, scroll to the very bottom and make sure the 'Enable Color' box is ticked.  

   .. figure:: images/hair_materials_color_inspector.png
      :align: center

      *Linked Hair Color Controls in the Inspector Window*

- This is intended to present a similar interface to that used for hair recoloring in Character Creator (in Modify - Material - Shader Settings).

   .. figure:: images/hair_recolor_cc4.png
      :align: center
      :width: 400

      *Hair Recoloring in CC4 (click to enlarge)*

- Enable Color will allow use of the Color fields for *Root Color*, *End Color*, *Highlight A Color* and *Highlight B Color* along with all of the blend controls.

.. |hair_color_enabled_X| image:: images/hair_color_enabled_X.png
                           :width: 260

.. |hair_color_X_txt| replace::
   Hair appearance with 'Enable Color' *Active*

.. |hair_color_enabled_O| image:: images/hair_color_enabled_O.png
                           :width: 260

.. |hair_color_O_txt| replace::
   Hair appearance with 'Enable Color' *Inactive*

.. Admonition::
   *Enabling Color - Expected Behavior*

   The immediate result of ticking/activating 'Enable Color' is that you may see a degradation in quality of the hair (this is especially noticeable for lighter hair colors). **This is expected behavior**. *Illustrated below:*

   .. list-table::
      :widths: 1 1
      :align: center
      :header-rows: 0
      
      * - |hair_color_enabled_X|
        - |hair_color_enabled_O|
      * - |hair_color_X_txt|
        - |hair_color_O_txt|

   **Please Note:** At the end of the baking process, chosen hair settings will be incorporated into the hair texture and the 'enable color' flag disabled - this will return the hair to a high quality appearance (with new coloring).



.. Tip::
   To allow for the fact that with 'Enable Color' *active* may look different to the eventual result, a means of previewing the final result has been added.   

   - Once the re-color settings have been made use the |BakeHair| button to simulate baking of the hair and apply that to the scene model.
   - Evaluate the settings to see if they are satisfactory. 
   - The bake simulation can be removed by clicking the |BakeHair_Yellow| button. This will leave the settings as they were when the simulation was applied, allowing you to fine tune the settings and quickly re-simulate them.
   - To reset the coloring to the original the re-build the materials.
   
*Workflow continues...*

- Adjust the color and blend controls to your preference.

- Simulate the final result with the |BakeHair_s| button.  If any refinement is needed, then remove the simulation with the |BakeHair_Yellow_s| button, then adjust the settings and try again.

- Once finished, remove the simulation (not needed but it will leave the hair simulation on the initial prefab - this can however be removed at any time.)

- Finalize any material settings as per :ref:`Basic Baking Workflow`

- Commit the current scene model to be baked with the |Bake_s| button.

The outcome of the bake is detailed in the :ref:`Basic Baking Workflow` section above.

|

Video Reference [Legacy]
------------------------

The basic baking workflow is show in the video below:

.. youtube:: 9sCRM0hUkc4

|     
