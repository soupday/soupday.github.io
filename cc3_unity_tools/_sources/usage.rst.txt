~~~~~~~
 Usage
~~~~~~~

Initial Import Into Unity
=========================

In **Character Creator**, or **iClone** prepare your character as you see fit.  

In **Character Creator** export the character using **Export -> FBX (Clothed Character)**.

.. image:: images/e1-cc3.png

Select the following options in the export window (you may need to scroll down to see all options).  

Target tool preset: **Unity 3D**, select: **Current Pose**, **Delete Hidden Faces**,  **Merge Beard and Brows into one object** and **Bake Diffuse and Specular maps from Digital Human Hair Shader**.

.. image:: images/e2-cc3.png

Click **Export** to begin the export process.


In **iClone** export the character using **Export -> Export FBX...**

.. image:: images/e1-iClone.png

Select the following options in the export window.

Target tool preset: **Unity 3D**, select: **Export Range = All**, **Delete Hidden Faces**, **Merge Face Hair to One Object**.

.. image:: images/e2-iClone.png

Click **Export** to begin the export process.


In **Microsoft Windows** open the file explorer and navigate to the export directory. In your **Unity 2020.3** or above project browser, navigate to the folder in your project where you will be placing your imported character.  

Now drag the <name>.fbx and <name>.json files & the textures and <name>.fbm (if present) folders from Windows file explorer into the project browser's target folder of your Unity project.

.. image:: images/initial_import.png



Opening The Import Tool
=======================

To open the import tool, you can right click on the **<name>.fbx avatar**

.. image:: images/fbx_avatar_small.png

From the right click menu select **CC3 → Import Character**

.. image:: images/rightclick_import.png

Alternatively, you can open the import tool from the top menu bar (**CC3 → Import Characters**) 

.. image:: images/menubar_import.png


This will open the main tool window (by default this will be docked next to the Scene Hierarchy View window – it is shown here undocked).

.. image:: images/floating_window.png

The import tool will actively detect all of the valid Character Creator 3 characters that are contained in the Unity project and display them vertically on the left hand side of the tool window. 

If your character is not displayed (or if no right click menu option is available to open the import tool) then **please ensure that all of the exported data from CC3 has been dragged into the Unity project browser** (there must be at least the .fbx and .json files and a textures folder containing a subfolder with the same name as the .fbx asset).



Beginning The Import
====================

Firstly ensure the character you wish to process is currently selected by clicking on the character icon (on the left hand side).  The currently selected character will be shown as follows.

.. image:: images/current_selection.png

The selected character is now ready to be processed.  The following options are available:

.. image:: images/default_button.png

**Default** processing will set up the character with materials using the system default HDRP/Lit and HDRP/Hair shaders that ship with Unity

.. image:: images/hq_button.png

**High Quality** processing will set up the character with materials using a custom ShaderGraph which replicates the visual quality of CC3 as closely as possible. 
Using the refractive option for eye rendering will produce the highest quality output (defaults to refractive).

.. image:: images/eye_options.png

This combination produces result with the highest visual quality.

.. image:: images/bake_button.png

**Bake** will create a new prefab which has consolidated all the texture influences into as simple a set of textures as possible with materials which a custom ShaderGraph shader or the system default HDRP/Lit and HDRP/Hair shaders – this is controlled by the checkbox (defaults to custom shader).

.. image:: images/bake_options.png

Baking is the most performance friendly option, whilst maintaining high visual quality.

.. image:: images/anim_button.png

**Animations** will process all of the animations contained in the .fbx and conform them to Unity's X,Y,Z co-ordinate system.

To begin processing click the appropriate button, Unity will then process the character and write a log file in the same directory as the .fbx file.  

Once processing is complete the tool window will be updated to reflect that.. The processed character icon will change color (Grey for Default processing, Green for HQ processing and  Orange for Baked processing).

Additionally, the status text will be updated with the type of processing that has been performed (highlighted below).

.. image:: images/floating_window_post_hq.png



Post Processing
===============

.. image:: images/preview_button.png

After processing has completed, the output character can be inspected in a preview scene by pressing the **'Preview Scene'** button.  This will open a new scene with neutral lighting; if your current scene is marked as changed then you will be prompted to save the current scene before changing to the preview scene.

.. image:: images/preview_scene_narrow.png

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



Tools Menu
==========

The **CC3 → Tools** menu can be used to further manipulate the character.  Before using any option here make sure the character you wish to manipulate is selected in the scene (blue outline)

.. image:: images/face_menu.png

**Reverse Triangle Order**

This option is occasionally needed to correct any anomalies with alpha blended materials.  This principal use of this is to ensure that hair materials are rendered in the proper order i.e. from inside to out.

**Prune Blend Shapes**

If a large number of blend shapes are exported with the character, then this option will cull those blend shapes which make a negligible contribution to the deformation of the model, leaving only those with a tangible effect.

**Open or Close Character's Mouth/Eyes**

This is useful for inspecting the character to ensure there are no hidden problems with the mouth and eyes.

.. image:: images/face_manipulation.gif

The eye menu **CC3 → Tools → Eye** enables movement of the eye direction for a detailed inspection of the eye.

.. image:: images/eye_manipulation.gif
