.. |br2| raw:: html

   <br /><br />

.. |br| raw:: html

   <br />

.. _conforming clothes in Character Creator: https://manual.reallusion.com/Character-Creator-4/Content/ENU/4.0/08_Cloth/Conforming_Clothing.htm?Highlight=conform

.. _CC/iC Blender Tools: https://github.com/soupday/cc_blender_tools

~~~~~~~
 Usage
~~~~~~~

.. youtube:: 6VIH5eXCioQ

| 

Preparing the Character for Import into Unity
=============================================

Before a character can be imported into Unity, it must first be properly exported from the relevant software package.  This tool can accept exports from Character Creator 3/4, iClone 7/8 and Blender 2.8 and above (the Blender case requires a CC3/4 or iClone 7/8 character as the starting point).

In **Character Creator**, or **iClone** prepare your character as you see fit.  

Export From Character Creator
-----------------------------

In **Character Creator** export the character using **Export -> FBX -> Clothed Character**.

.. image:: images/cc4-export-menu.png
    :align: center
    :width: 400

|

Select the following options in the export window (you may need to scroll down to see all options).  

Target tool preset: **Unity 3D**, select: **Current Pose**, **Delete Hidden Faces**,  **Merge Beard and Brows into one object** *(Optional)* and **Bake Diffuse and Specular maps from Digital Human Hair Shader**.

.. image:: images/cc4-export-top.png
    :align: center
    :width: 550

|

Further settings are available by scrolling down. Please note **Delete Hidden Faces** is not currently selected by default.

.. image:: images/cc4-export-bottom.png
    :align: center
    :width: 550

.. 
    image:: images/e2-cc3.png

|

Click **Export** to begin the export process.

.. tip::
    If the character is placed in its own folder then it can be easily removed or moved around.  Should you wish to export multiple characters into the same folder, they will co-exist safely without overwriting each other's data and can be manipulated collectively.

.. warning::
    If you are exporting directly into a Unity project, then **please wait for the export process to complete before switching to the Unity application**. Otherwise Unity will detect new files as they are being written and will lock them before they are completely exported - causing an inconsistent mess.
     


Export From iClone
------------------

In **iClone** export the character using **Export -> Export FBX...**

.. image:: images/e1-iClone.png
    :align: center
    :width: 300

|

Select the following options in the export window.

Target tool preset: **Unity 3D**, select: **Export Range = All**, **Delete Hidden Faces**, **Merge Face Hair to One Object**.

.. image:: images/ic8-export-main.png
    :align: center    

.. |advexp| image:: images/ic8-export-adv-button.png

|

If you are exporting facial animations, then enter the advanced export settings using the |advexp| button.  Ensure that **Mouth Open as Morph** is *un-ticked* (it is currently enabled by default) otherwise the facial animations will be incorrectly exported.

.. image:: images/ic8-export-adv.png
    :align: center    

.. 
    image:: images/e2-iClone.png

|

Click **Export** to begin the export process.

..
    Export From Blender
    -------------------

    If you are using the `CC/iC Blender Tools`_ you may export the character directly into Unity.  This process has the basic requirement that the T-Pose is the first animation in the Blender Action stack.  

    If a T-Pose cannot be found, then the subsequent import into Unity will fail and the character will be distorted.  Since the organization of actions in Blender is to say the least opaque, the CC/iC Blender Tools provide a simple solution.

    The workflow to export a Character Creator or iClone character from blender is as follows:

    .. _Rigify Creation Workflow: https://soupday.github.io/cc_blender_tools/animation.html#creating-a-rigify-control-rig

    - Create a Rigify Control rig for the character by following the `Rigify Creation Workflow`_.  This will ensure that when exported to Unity, the proper T-Pose is included.

    .. _Retargeting Animations Workflow: https://soupday.github.io/cc_blender_tools/animation.html#retargeting-animations-to-the-rigify-control-rig

    - Retarget any animations you want to be included with the character by following the `Retargeting Animations Workflow`_.  These animations will play on the Rigify rigged character and can be edited using the control rig.

    - Once you are satisfied with the animations and any edits you have made - **Save the Blend file**. The following steps will add new Unity specific objects which will clutter your blend file.

    - To allow clean animation import into Unity, and to avoid importing any extra control rig objects the animations must be converted to a clean Unity specific skeleton - this is done automatically with a single button press.

    - Navigate to and open the *Unity* foldout of the of the *Retargeting* pane (it is closed by default). 

    .. figure:: images/Blender-Unity-Retarget.png
        :align: center

        *Blender Tools - Unity Retargeting*

    - If your animations are stored as *Blender Actions* then use the *Bake Unity Animation* button.

    - If you are using the *NLA* and have 'pushed down' actions into *NLA strips*, then use the *Bake NLA to Unity* button instead. 

    - Leave *Bake Shape Keys* selected if you want to transfer facial animation.

    - Immediately below the *Unity Retarget* functions there is an *Export to Unity* tool. (This can also be found in the *Import/Export* pane). 

    .. figure:: images/Blender-Unity-Export.png
        :align: center

        *Blender Tools - Unity Exporter*

    - In the *Blender Outliner* ensure that the newly created <Model>_Rigify is selected.

    .. figure:: images/Blender-Unity-Selected.png
        :align: center

        *Blender Outliner*

    - If your animations are stored as *Blender Actions* then ensure that *Actions* is highlighted (default)

    - If you are using the *NLA* and have 'pushed down' actions into *NLA strips*, then ensure that *Strips* is highlighted instead.

    - Press the *Export to Unity* button.  

    - In the file dialog that appears, you may choose wether or not to export animations with the character, and if only the selected objects are exported.

    .. figure:: images/Blender-Unity-Export-Options.png
        :align: center

        *File Options*

    |

    Click **Export** to begin the export process.

Considerations to Avoid Clipping
--------------------------------

Typically, to avoid the issue of meshes beneath clothing items penetrating through during animation, the **Delete Hidden Faces** is used to cull any parts of the model that cannot be seen directly.

Whilst this is usually fine, there may be circumstances where it is not desireable to do this (or the clothing items are being clipped thorough in Character Creator itself).

In such circumstances please see the `conforming clothes in Character Creator`_ section of the Character Creator 4 documentation for a guide on eliminating clipping.


Importing into Unity
====================

In **Microsoft Windows** open the file explorer and navigate to the export directory. In your **Unity 2020.3** or above project browser, navigate to the folder in your project where you will be placing your imported character.  

Now drag the <name>.fbx and <name>.json files & the textures and <name>.fbm (if present) folders from Windows file explorer into the project browser's target folder of your Unity project.

.. image:: images/initial_import.png


Opening The Import Tool
=======================

To open the import tool, you can right click on the **<name>.fbx avatar**

.. image:: images/fbx_avatar_small.png
    :align: center
    
|

- From the right click menu select **Reallusion → Import Character**

- Alternatively, you can open the import tool from the top menu bar (**Reallusion → Import Characters**) 
    
|

This will open the main tool window (by default this will be docked next to the Scene Hierarchy View window - it is shown here un-docked).

.. image:: images/tool_new_ui.png
    :align: center
    
|

The import tool will actively detect all of the valid Character Creator or iClone characters that are contained in the Unity project and display them vertically on the left hand side of the tool window. 

If your character is not displayed (or if no right click menu option is available to open the import tool) then **please ensure that all of the exported data from Character Creator or iClone has been dragged into the Unity project browser** (there must be at least the .fbx and .json files and a textures folder containing a subfolder with the same name as the .fbx asset).

.. |refresh| image:: images/new_ui_refresh.png
    :width: 28

If you add a character to the project whilst the tool is open, you can refresh the available character list with the |refresh| button.

Beginning The Import
====================

Firstly ensure the character you wish to process is currently selected by clicking on the character icon (on the left hand side).  The currently selected character will be shown as follows.

.. image:: images/current_selection.png
    :align: center

|

The selected character is now ready to be processed.  The following options will be initially available:

Initial Processing
==================


Quality Settings
----------------

The three principal quality settings are presented as dropdown menus, with the defaults pre-selected as shown below.

.. image:: images/new_ui_quality_settings.png
    :align: center

|

The following dropdown options are available:

.. |mats| image:: images/new_material_settings.png

.. |matstxt1| replace:: 
    **High Quality Materials** *(Default)* processing will set up the character with materials using a custom ShaderGraph which replicates the visual quality of Character Creator as closely as possible.

.. |matstxt2| replace:: 
    **Basic Materials** processing will set up the character with materials using the system default shaders that ship with Unity - This should only ever be used as a draft import.

.. |eyes| image:: images/new_eye_settings.png

.. |eyestxt1| replace::
    **Basic Eyes** This option will use a simpler shader for the eye, but will still offer good quality for a lower performance overhead.

.. |eyestxt2| replace::
    **Parallax Eyes** *(Default)* This option will apply a high quality shader to the eyes which attempts to properly simulate the refractive properties of the eye, offering excellent visual quality. this shader also allows control over eye attributes such as pupil size.

.. |eyestxt3| replace::
    **Refractive (SSR) Eyes** *(HDRP pipeline only)* Screen Space Refraction (SSR) is a "HDRP feature that uses the depth and color buffer of the screen to calculate refraction".

.. |hair| image:: images/new_hair_settings.png

.. |hairtxt2| replace::
    **Two Pass Hair** *(Default)* This option will apply two materials to the hair meshes (and thus use two material passes). Two pass hair is generally higher quality, where the hair is first drawn opaque with alpha cutout and the remaining edges drawn in softer alpha blending, but can come at a performance cost (whilst this is the default, it is best suited to close up shots). 

.. |hairtxt1| replace::
    **Single Pass Hair** This option will apply a single pbr material to the hair meshes, whilst having lower performance this also offers lower visual fidelity (this should be used as the general use case).

.. |hairtxt3| replace::
    **MSAA Coverage Hair** *(Available only when amplify shaders are used - not available in HDRP)* This option is intended to be used when MSAA (Multi-Sample Anti-Aliasing) is enabled in post processing to provide low cost high quality results.

.. |shaderfeat| image:: images/new_shader_features.png

.. |feattxt1| replace::
    **Features** (Multiple features can be simultaneously selected)

.. |feattxt2| replace::
    **Tesselation** *(HDRP v12)* For HDRP 12 (Unity 2021.2+) all shader graph shaders can have tessellation enabled.  If enabled, will add additional :ref:`Tesselation Options` in the :ref:`Materials Inspector`.

.. |feattxt3| replace::
    **Cloth Physics** Will enable :ref:`Cloth Physics` - During 'Build Materials' This will construct colliders, constraint paint applicable clothing items and set them to use the character's colliders with the Unity built in physics system.  

.. |feattxt4| replace::
    **Hair Physics** Will enable hair physics during 'Build Materials' in much the same way that cloth physics is enabled. **Consider this to be highly experimental.** **Warning: this will be VERY detrimental to performance.**


.. list-table::
   :widths: 19 31
   :header-rows: 0

   * - |mats|
     - |matstxt1|
       |br2|
       |matstxt2|
   * - |eyes|
     - |eyestxt1|
       |br2|
       |eyestxt2|
       |br2|
       |eyestxt3|
   * - |hair|
     - |hairtxt1|
       |br2|
       |hairtxt2|
       |br2|
       |hairtxt3|
   * - |shaderfeat|
     - |feattxt1|
       |br2|
       |feattxt2|
       |br2|
       |feattxt3|
       |br2|
       |feattxt4|

|

.. |FurtherSettings| image:: images/additional_settings.png

.. |FurtherSettings_s| image:: images/additional_settings.png
    :width: 28

Further Settings
----------------

Clicking on the settings icon |FurtherSettings_s| will show a secondary settings panel.

.. figure:: images/additional_settings_panel.png
    :align: center

    *HDRP settings panel*

The options available in this panel are dependent on the pipeline version used; all available options are discussed below.

.. |settxt1| replace::
    **Use Amplify Shaders** *(3D and URP pipelines ONLY)* Use shaders made with the *Amplify Shader Editor* for which has higher quality anisotropic lighting of the hair at a minimal performance cost.  Amplify shaders are capable of subsurface scattering effects, and anisotropic hair lighting in the URP and Build-in 3D pipelines.

.. |settxt2| replace::
    **Reconstruct Flow Map Normals** *(All pipelines)* Rebuild missing Normal maps from Flow Maps in hair materials. Reconstructed Normals add extra detail to the lighting models.

.. |settxt3| replace::
    **Rebake Blender Unity Maps** *(All pipelines)* When active will always re-bake the blender to unity Diffuse+Alpha, HDRP Mask and Metallic+Gloss maps. Otherwise subsequent material rebuilds will try to re-use existing bakes. Only needed if the source textures are changed.

.. 
    .. |settxt4| replace::
        **Use Tessellation in Shaders** *(HDRP pipeline only)* Use tessellation enabled shaders where possible. For HDRP 10 & 11 this means default shaders only (HDRP/LitTessellation). For HDRP 12 (Unity 2021.2+) all shader graph shaders can have tessellation enabled.

.. |settxt5| replace::
    **Animation Player On** *(All pipelines)* Always show the animation player when opening the preview scene.

.. |settxt7| replace::
    **Physics Collider Shrink** Coefficient to specify if the colliders should be reduced or enlarged: +ve numbers shrink the collders and -ve numbers enlarge them.

.. |settxt8| replace::
    **Physics Collider Detection Threshold** The weight threshold (from the weight map + power/offset/scale) that must be reached before a collider can be assigned to the cloth when optimized colliders are being assigned to <Cloth> components by the physics Weight Mapper.  This is a global default value see :ref:`The <WeightMapper> component` documentation for details.


.. |settxt6| replace::
    **Log Level** Here you can opt to change the console logging level to: Errors Only, Warnings & Errors (default) or Everything 

- |settxt1|

- |settxt2|

- |settxt3|

- |settxt5|

- |settxt7|

- |settxt8|

- |settxt6|

.. |settingsback| image:: images/settings_back.png
    :width: 28

You can return to the main tool window from the settings panel by clicking the back button. |settingsback|

|

Once you have set your options  then the model can be processed by clicking the 'Build Materials' button, Unity will then process the character and write a log file in the same directory as the .fbx file.  

.. image:: images/build_button.png
    :align: center

|

Once processing is complete the tool window will be updated to reflect that.. The processed character icon will change color (Grey for Default processing, Green for HQ processing and  Orange for Baked processing).

All of the animations (with the exception of the T-Pose) will also be extracted from the imported fbx, and have all of the Blend Shapes in those animations retargeted to animate all of the objects in the processed model.

This processing is necessary since two-pass hair processing adds new hair objects which would otherwise require manual Blend Shape retargeting in order to animate properly.  This allows the animations to be used 'out of the box'.

The animation is placed in a subfolder of the folder containing the fbx file and renamed to <MODEL_NAME>_Imported_<Animation_Name>.anim

.. code-block::

  <Import Folder>
    |-- Animations
    |     |-- <MODEL_NAME>
    |           |-- <MODEL_NAME>_Imported_<Animation_Name_1>.anim
    |           |-- <MODEL_NAME>_Imported_<Animation_Name_2>.anim
    |
    |-- <MODEL_NAME>.fbm
    |-- textures
    |-- <MODEL_NAME>.fbx
    |-- <MODEL_NAME>.json

The first animation in the list will also be the default animation in the preview scene animation player.

Additionally, the status text will be updated with the type of processing that has been performed (highlighted below).

.. image:: images/post_hq_processing.png
    :align: center
    
|

Once the (High Quality) processing has been completed, a prefabs directory will be created in the same directory as the imported character .fbx file and a unity prefab of the imported character will be placed into it. 

|

Further Processing
------------------

After initial processing further options will become available.

.. |Bake| image:: images/new_ui_bake.png

.. |Bake_s| image:: images/new_ui_bake.png
    :width: 28

Baking |Bake|
-------------

Baking is the most performance friendly option, whilst maintaining high visual quality.  Two principal options are available as dropdown menus as before.

.. image:: images/new_ui_bake_options.png
    :align: center

|

**Bake** will create and apply new materials which have consolidated all the texture influences into as simple a set of textures as possible to enhance performance.

.. |bksh| image:: images/new_ui_bake_shaders.png

.. |bkshtxt1| replace::
    **Custom Shaders** *(Default)*  Uses materials with a custom ShaderGraph shader for very high quality and very good performance.

.. |bkshtxt2| replace::
    **Default Shaders** Uses the system default pbr shaders in the baked output, if performance is desired above all else, at the cost of visual quality.

.. |bkpre| image:: images/new_ui_bake_prefab.png

.. |bkpretxt1| replace::
    **Separate Baked Prefab** *(Default)* The baked output will be written to a new prefab <name>_baked (in the same directory as the initially created prefab).

.. |bkpretxt2| replace::
    **Overwrite Prefab** This option will overwrite the initially (when the materials are built during initial processing) created prefab with new materials and textures.  This feature is used principally for the 'iClone Live Link'. 

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

Once the desired options have been set, then the process can be started with the |Bake_s| button.

Any changes that are made to the main processing options (material quality, eye and hair settings) and then reprocessed *via* 'Build Materials' will cause the baked prefab to be automatically updated with those new settings.

The Baking workflow is show in the video below:

.. youtube:: 9sCRM0hUkc4

|     


.. |anim| image:: images/new_ui_anim.png

.. |anim_s| image:: images/new_ui_anim.png
    :width: 28

Animations |anim|
-----------------

The animation button |anim_s| will re-process all of the animations contained in the fbx, and re-create the same default output as the build process did.

This will also create a default animator controller will all the fbx's animations in it as states.

|

Post Processing
===============

.. |preview| image:: images/new_ui_preview.png

.. |preview_s| image:: images/new_ui_preview.png
    :width: 28

Preview Scene |preview|
-----------------------

After processing has completed, the output character can be inspected in a preview scene by pressing the **'Preview Scene'** button |preview_s|.

This will open a new scene with neutral lighting; if your current scene is marked as changed then you will be prompted to save the current scene before changing to the preview scene.

.. image:: images/preview_scene_2.png

Several preview scene specific tools are included on the main button strip (of the main tool window) for user convenience:

.. |prev_light| image:: images/preview_lighting_model.png

.. |pref_cam_align| image:: images/preview_camera_align.png

- |prev_light| *Preview Scene Lighting* This will cycle through several pre defined lighting setups to allow you to rapidly assess the character under a range of lighting conditions.

- |pref_cam_align| *Align main camera with current scene view* This will align the main camera in the preview scene with the current orientation of the view in the *Scene Window* (i.e. it will align the *Game window* with what you are seeing in the *Scene Window*).

By default, the preview scene contains a small tool to allow you to preview animations and facial expressions on your character.  The previews are performed in **Edit Mode** only, so that the Unity project itself **doesn't have to enter Play Mode** (which, for complex projects is desireable).  The tool itself is controlled from an embedded pane in the SceneView window (In Unity versions below 2021.2.0 this will appear as a standard Gui window, above 2021.2.0 the tool will be contained in a more versatile (and moveable) overlay window).

.. image:: images/char_preview_toolpane.png

The tool pane has two sections (each can be minimized/revealed by clicking it's foldout button).

.. |animplayer| image:: images/new_ui_anim_player.png

.. |animplayer_s| image:: images/new_ui_anim_player.png
    :width: 28

Animation player |animplayer|
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

The animation player can play any appropriate `Mechanim <https://docs.unity3d.com/Manual/AnimationOverview.html>`_ animation from your project on the character in the preview scene (by using the *'Animation'* selector).  The controls for this are standard (play/pause advance one frame back/forward and go to start/end) additionally dragging the 'Time' bar will allow you to spool manually through the animation.  Additionally, any model (with an animator component) may be dragged into the scene and selected in the *'Scene Model'* object selector to allow animations to be played on it.

The animation player/facial expression tool may be toggled on/off with the |animplayer_s| button.

NB:  When an animation is playing, the facial expression controls are locked out.

Facial Expression
~~~~~~~~~~~~~~~~~

This section controls numerous aspects of facial manipulation it was introduced to replace the older menu driven facial manipulation and contains some useful features.  The tool is included as part of the animation player window.  

.. image:: images/eye_2d_slider.png
        :align: left

.. |reset-face|  image:: images/reset_face_button.png

The eye control tool is used to 'zoom in' on the face (double click anywhere on the 'eye' graphic).  This will change the scene view to look directly at the face of the character no matter what the position of the head is (this may result in unusual camera angles - this can be rectified by double clicking on the |reset-face| icon to return to a neutral angle).

Dragging the handle in the centre of the eye control tool will move the rotation of the eyes allowing detailed inspection of the eyes and the area of the face around the eyes are they are moved in real time.

.. image:: images/eye_control_tool.gif

Eye blink and mouth open/close can be controlled using the sliders:  

.. image:: images/mouth_blink_sliders.png

As above these manipulate the character model in real time with no (as previous) menu usage.

.. image:: images/mouth_blink_control.gif

A predefined set of facial expressions have been added so that these can be quickly previewed on the character with minimal effort.

.. image:: images/face_button_strip.png

Repeatedly clicking on a button will increase the strength of the expression applied to the character.

.. image:: images/expression_control.gif

At any time, clicking on the |reset-face| icon will reset the face of the character (and double clicking will reset the camera).

|

Materials Inspector
-------------------

The objects, materials and textures used in the model can be easily inspected from the hierarchical tree view.  Selecting any of the items in the tree viewer will select them within your Unity project and display them in the inspector. 

.. image:: images/material_explorer.png

If  **'Select Linked'** is checked (by default this is checked) then when a material is selected then all others with common properties are also selected, displaying all members of the selected group in the inspector. 

.. image:: images/select_linked.png

The **'selectable groups'** are **'Skin materials'**, **'Eye materials'**, **'Eye occlusion'** and **'Teeth materials'**
This will multiple select all of the materials associated with the 'selectable group'  and present all of the common attributes in the inspector window.

.. image:: images/multi_material_selected.png

This allows the simultaneous property adjustment of 'like' materials. For example selecting eye materials will allow the simultaneous adjustment of both left and right eyes.

.. image:: images/selected_eyes.png

Example adjustment – working zoomed in on one eye will also update the other eye for consistency:

.. image:: images/pupil_manipulation.gif

Tesselation Options
~~~~~~~~~~~~~~~~~~~

If the materials have been built with the 'Tesselation' feature enabled (HDRP 12+), then a tesselation options section becomes available in the materials inspector. 

.. figure:: images/tess_options.png
    :align: center
    
    *Enabled Tesselation Options*

The shaded wireframe gif below shows the effect of ramping the 'Tesselation Factor' from 0 to 32:

.. figure:: images/face_tesselation_s.gif
    :align: center
    :width: 400

    *Tesselation Factor Changes*

This allows a higher density mesh to be simulated by the shader.

Tools Menu
==========

The **Reallusion → Tools** menu can be used to further manipulate the character.  Before using any option here make sure the character you wish to manipulate is selected in the scene (blue outline)

.. image:: images/face_menu.png

Reverse Triangle Order
----------------------

This option is occasionally needed to correct any anomalies with alpha blended materials.  This principal use of this is to ensure that hair materials are rendered in the proper order i.e. from inside to out.  To use this, select the **hair mesh** of a model in the scene and use the menu option **Reallusion -> Tools -> Reverse Triangle Order**.

|

Prune Blend Shapes
------------------

If a large number of blend shapes are exported with the character, then this option will cull those blend shapes which make a negligible contribution to the deformation of the model, leaving only those with a tangible effect.

|

Auto Smooth mesh
----------------

If Unity encounters a mesh that has differing vertex data (e.g. from split normals) then unity will split that mesh into separate faces and it will give the appearance of being flat shaded.

.. |flat mesh| image:: images/mesh_flat_shaded.png
                :width: 300
                :alt: Before auto smooth

.. |smooth mesh| image:: images/mesh_smooth_shaded.png
                :width: 300
                :alt: After auto smooth

Usage:  with the object selected use the menu option **Reallusion -> Tools -> Auto Smooth Mesh**

Illustrated below: **Left** Apparent flat shading. **Right** Smooth shading after 'auto smooth'

|flat mesh| |smooth mesh|

|

Orbit Scene View
----------------

The scene camera can be made to slowly orbit the character by using **Reallusion -> Tools -> Orbit Scene View** (to stop the orbit select this menu option again).  If the character is animating and moving around then the rotation can track the character using **Reallusion -> Tools -> Orbit Scene View (Tracking)** (again this cn be stopped by selecting the menu item again).

|

Open or Close Character's Mouth/Eyes [Legacy]
---------------------------------------------

This is useful for inspecting the character to ensure there are no hidden problems with the mouth and eyes.

.. image:: images/face_manipulation.gif

The eye menu **Reallusion → Tools → Eye** enables movement of the eye direction for a detailed inspection of the eye.

.. image:: images/eye_manipulation.gif

