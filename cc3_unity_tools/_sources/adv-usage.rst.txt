.. |br2| raw:: html

   <br /><br />

.. |br| raw:: html

   <br />

.. _Blender tools for Character Creator/iClone: https://github.com/soupday/cc_blender_tools/releases

.. _Alembic: https://en.wikipedia.org/wiki/Alembic_(computer_graphics)

~~~~~~~~~~~~~~~~
 Advanced Usage
~~~~~~~~~~~~~~~~

.. |animretarget| image:: images/new_ui_anim_retarget.png

Animation Retargeting |animretarget|
====================================

From time to time when using 3rd party animations on Character Creator characters, there are apparent errors arising from a mismatch between the source animation skeleton and the Character Creator skeleton.

The most common errors are 'hunched' shoulders and malformed hands.  Many Unity users will also encounter the 'open mouth' issue wether they use Character Creator or not; this being an artefact of the Mechanim animation system and the way it handles open/closed jaw data.

To this end, a simple tool-set has been provided to interactively adjust problematic aspects of the animation with real-time preview of those adjustments **directly onto the target model** (via the animation player).  A simple tool to correct only open jaw data has been included as a bonus.

The retargeting tools are available **Only In The Preview Scene** by pressing the |animretarget| *Animation Adjustment & Retargeting* button.

This will bring up a fixed window in the bottom-left corner of the Scene View (Unity 2020) or a dragable overlay window (Unity 2021+).

.. figure:: images/anim_retarget_tools.png
    :align: center

    *Animation Retarget Tools Window*


Animation Retarget Tools
~~~~~~~~~~~~~~~~~~~~~~~~

The animation retarget tools will operate on the **currently selected** **Scene Model** and **Animation** in the *Animation Playback* section of the *Character Preview Tools window*.

.. figure:: images/selected_model_anim.png
    :align: center

    *Selected Model and Animation*

.. |retargethand| image:: images/retarget_hand.png

.. |retargetreset| image:: images/retarget_reset.png

.. |retargetsave| image:: images/retarget_save.png

Any Adjustments made can be previewed on the *scene model* using the animation playback (straightforward Play or spool through the animation with the Time slider).  

The adjusted animation can be saved into the 'home directory' of the *scene model* by pressing the *save button*. |retargetsave|

- Specifically the animation will be saved to <model FBX dir>/Animations/<Model Name>/  (The project explorer will be focused onto this directory when the animation is saved).

- The animation will be renamed to <Model name>_<Original animation name>.anim  - Any illegal filesystem characters will also be stripped out and replaced with a '-' symbol.

- Multiple saves will not overwrite; the animation name will instead be appended with an increasing '.000' '.001' for each save. 

- The animation can be reset to it's original state at any time by pressing the *reset button*. |retargetreset|

- No changes are ever made to the original animation - the process is entirely non destructive.

Hand Correction |retargethand|
------------------------------

Three options are available for hand correction:

- *Original* This option will use the original data for both hands in the animation track.  This option can be selected to *undo* any hand changes made by the other options.

- *Open* This will change all of the hand pose data in the animation into a static open hand pose.

- *Closed* This will change all of the hand pose data in the animation to a static closed hand pose.

.. 
    290, 270, 217

.. |handoriginal| image:: images/retarget_hand_original.png
    :width: 290

.. |handopen| image:: images/retarget_hand_open.png
    :width: 270

.. |handclosed| image:: images/retarget_hand_closed.png
    :width: 217

Select either with the radio button or cycle through the options by pressing the hand icon |retargethand|.

.. list-table::
  :widths: 145 135 110
  :header-rows: 0
  
  * - |handoriginal|
    - |handopen|
    - |handclosed|      
  * - *Original*
    - *Open*
    - *Closed*

**NB** The original pose is specific to the source animation (the one illustrated above is slightly malformed to demonstrate the potential utility of the tool).

Animation Track Correction
--------------------------

The Animation Track Correction controls allow the adjustment of specific portions of the animation where mismatches may occur.  i.e the Shoulders, Arms, Legs, Heels and the Vertical displacement of the animation (Height).

.. figure:: images/animation_track_sliders.png
    :align: center
    
    *Correction Controls*


The result of each control's action is presented visually below:

.. |shoulder_corr| image:: images/shoulder_correction.gif
    :width: 229

.. |arm_corr| image:: images/arm_correction.gif
    :width: 229

.. |leg_corr| image:: images/leg_correction.gif
    :width: 229

.. |heel_corr| image:: images/heel_correction.gif
    :width: 229

.. list-table::
  :widths: 4 3
  :header-rows: 0
  
  * - *Shoulder Correction*, Adjust the Up-Down displacement of the Shoulders across the whole animation.
    - |shoulder_corr|           
  * - *Arm Correction*, Adjust the Upper Arm Up-Down rotation. Controls the 'lift' of the arms.
    - |arm_corr|
  * - *Leg Correction*, Adjust the Upper Leg In-Out rotation. Controls the width of the character's stance.
    - |leg_corr|
  * - *Heel Correction*, Adjust the angle of the Foot Up-Down rotation. Controls the angle of the heel.
    - |heel_corr|

The effect of each of the controls will be applied across the whole animation (the controls are not keyable).  These controls are only intended as a minor corrective measure; should you require more in-depth corrections then consider using the `Blender tools for Character Creator/iClone`_ which allow the use of the Rigify control rig in a sophisticated animation package.

Jaw Open Correction [Retarget Tools]
------------------------------------

.. |open_icon_s| image:: images/retarget_open_icon.png
    :width: 30

If an animation is imported without any proper jaw data then the Unity Mechanim system will construct a placeholder animation curve called "Jaw Close" with '0' as each keyframe value; however Jaw Close = 0 means that the jaw is open.

This can be remedied by hand by making a duplicate of the animation clip then editing all the keyframes in the Jaw Close animation curve to have a value of 1. 

Alternatively you can use the retarget tool and press the close jaw toggle |open_icon_s|

The icon will change between open and closed mouth to show which mode its in.

.. admonition:: Caution

    This feature will overwrite any jaw data in the animation curve and replace the whole animation with 'Jaw Closed'.  As such, it should only be used when 3rd party animations are playing with a permanent open mouth.


.. |open_head| image:: images/retarget_open_head.png

.. |open_icon| image:: images/retarget_open_icon.png

.. |closed_head| image:: images/retarget_closed_head.png

.. |closed_icon| image:: images/retarget_closed_icon.png

.. list-table::
  :widths: 1 1
  :header-rows: 0
  
  * - |open_head|
    - |closed_head|     
  * - |open_icon| - Original curve data.
    - |closed_icon| - Closed jaw curve data.
    
Jaw Open Correction [Standalone]
--------------------------------

A quick alternative means of performing 'jaw open' correction has also been provided.

- Navigate in the project browser to the fbx which contains the animation you wish to close the jaw for.

- Right click and select the **Quick Animation Processing -> Process Jaw Animations** option.

- **All** of the animations in the fbx will be processed with a closed jaw and saved into the same folder as the source fbx file.

- The animations will be renamed to <FBX name> - <Animation Clip Name>.anim (illegal filesystem chars will be stripped out and replaced with a ‘-’ symbol).

- Again, multiple saves will not overwrite; the animation name will instead be appended with an increasing '.000' '.001' for each save.

- If any jaw data is present in the animation then the process will notify with a console warning and fail.  An option to force processing is available at **Quick Animation Processing -> Process Jaw Animations (Force)**

BlendShape Retargeting
----------------------

When the selected animation clip contains BlendShape animations (for example iClone AccuLips or facial expression performances) then these often do not play correctly on a different character model due to differences in the face objects (eyebrows, beards, moustaches etc).  This is illustrated below with the ExPlusFacial Demo animation being played on a character with extra face 'furniture'.

.. figure:: images/face_blendshape_mismatched_post.gif
  :width: 200
  :align: center

  *Face objects not obeying Blend Shape animations*

.. |blendshaperetarget_s| image:: images/retarget_blendshape.png
    :width: 30

The BlendShape Retarget function |blendshaperetarget_s| will copy the existing BlendShape animation data in the **currently selected Animation** and copy it to all of the applicable objects in the **currently selected Scene Model** (which must contain the appropriate BlendShape definitions) allowing them to animate correctly.

*Usage:*

.. warning::

  When exporting from iClone, ensure in the advanced options that '**Mouth Open as Morph**'' is **NOT** selected.  Otherwise corruption of the BlendShape data may occur.


- Select the appropriate **Scene Model** and source **Animation** in the *Animation Playback* section of the *Character Preview Tools window*

- Press the BlendShape Retarget |blendshaperetarget_s| button.  There will be a brief pause after which the updated animation can be previewed using the normal *Animation Playback* functions.

- Once you are happy with the BlendShapes the animation can be saved (this will save all of the adjustments made with the animation retarget tool) using the *save button*. |retargetsave|

Once the BlendShape retarget is complete, the animation player will show (for our example) the following:

.. figure:: images/face_blendshape_corrected_post.gif
  :width: 200
  :align: center

  *Face objects now have proper animation data*

.. admonition:: Note

    Use of the 'Jaw Close' function will likely interfere with facial BlendShape animations and is best avoided when dealing with them.

|

.. |Alembicretarget| image:: images/Alembic_texture_retarget.png

.. |Alembicretarget_s| image:: images/Alembic_texture_retarget.png
    :width: 20

Alembic Texture Retargeting |Alembicretarget|
=============================================

The `Alembic`_ file format is used to store baked geometry from an animated scene (amongst other things). In the context of iClone exports, it is used to capture baked *Soft Cloth* physics for further use in a different rendering or lighting package.

An exported Alembic file can be imported into Unity, however it will lose all of its material and texture data and appear as a blank white model.

The *Alembic Texture Retarget* function |Alembicretarget_s| allows the automated transfer of material and texture data from a Character Creator/iClone character onto the corresponding Alembic export from iClone.

Requirements
~~~~~~~~~~~~

The use of Alembic (.abc) files requires the installation of the Alembic package from the 'Unity Registry' please see the :ref:`Optional Installation` section for details.

Workflow - iClone to Unity [Experimental] 
-----------------------------------------

- In iClone, Set up the character to be animated and animate it however you wish.

- In the iClone *Project* window; ensure *Soft Cloth* - *Bake Animation* is selected in the *Global Physics Settings* section.

.. figure:: images/iclone_physics_settings.png
  :align: center
  :width: 200

|

- On the animated character ensure that *Activate Physics* is enabled for all of the objects that need to have their physics simulation baked.

.. figure:: images/iclone_object_physics_settings.png
  :align: center
  :width: 200

|

.. |byframe| image:: images/by_frame_time_mode.png

- In the animation playback pane ensure that the *Time Mode* is set to *By Frame*. |byframe|

- Play the animation through once to cache the physics data as a vertex animation track for each applicable object.  This is shown in the timeline below:

.. figure:: images/timeline_soft_cloth.png
  :align: center
  :width: 600

  *Physics baked as Soft Cloth Vertex Animation tracks*

- Now export the animated character as FBX for Unity see: :ref:`Export From iClone`  (this will be the reference model for textures and materials - so no animation data is needed). **Give the model a simple name** *<MODEL_NAME>*.

- Now export the character as Alembic with the file format set to *Ogawa* and *Split Mesh by Material* selected.

.. figure:: images/iclone_Alembic_export_settings.png
  :align: center
  :width: 200

|

- Name it **<Your choice of animation name>.abc**

*Once everything is exported, it must be transferred into Unity.*

- Open your unity project and drag in the FBX export you made earlier.  You should end up with a file structure like this:

.. code-block::

  <Import Folder>
    |-- <MODEL_NAME>.fbm
    |-- textures
    |-- <MODEL_NAME>.fbx
    |-- <MODEL_NAME>.json


- Create a folder in the <Import Folder> called "Alembic" with a sub-folder called <MODEL_NAME> and place the exported Alembic file (<Your choice of animation name>.abc) inside it.

- The folder layout should now be:

.. code-block::

  <Import Folder>
    |-- Alembic
    |     |-- <MODEL_NAME>
    |           |-- <Your choice of animation name>.abc
    |
    |-- <MODEL_NAME>.fbm
    |-- textures
    |-- <MODEL_NAME>.fbx
    |-- <MODEL_NAME>.json

.. tip:: 
  
  This file structure is designed to allow placing of multiple models in <Import Folder> so that they don't interfere with each other.

- Multiple different Alembic files may be placed in the 'Alembic/<MODEL_NAME>' folder.  They will all be processed at once.

*Once the files are all imported into the correct place then can then be processed with the CC/iC Import Tools for Unity.*

- Open the import tool and for the *Reference Model* (<MODEL_NAME>.fbx) follow the procedure here: :ref:`Initial Processing`.  This will create all the materials needed to properly display the model.

- Finally press the |Alembicretarget_s| *Alembic Texture Retarget* button to create a prefab which has all of the material data from the *Reference Model* correctly applied to the Alembic Animation. (Multiple .abc files will give multiple prefabs).

- The project explorer will be automatically focussed onto the prefab directory (which will be <Import Directory>/Alembic/<Model_Name>/Prefabs/)

The generated prefabs can now be freely used in your scenes.  The video below is an iClone baked Soft Cloth simulation exported as Alembic with materials reconstructed from an fbx exported reference model, played with the Unity timeline.

.. |vid| raw:: html

    <video width="695" height="417" controls src="_static/alembic.mp4"></video> 

|vid|

.. tip::

  The generated prefabs are only pointers to the animation and material information - they do not use up any extra disk space compared to the enormous size of the .abc files