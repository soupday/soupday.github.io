========
Examples
========

.. contents::

~~~~~~~~~~~
First Steps
~~~~~~~~~~~

- In character creator, make any character you like and dress them up.

.. image:: images/ex1_cc3_char.jpg
  :width: 600

- Export the character as **FBX (Clothed Character)**. Set the target tool preset to **Blender**, The FBX options to **Mesh and Motion**.
  You can Embed the textures if you want, but it's usually better not to as embedding the textures stores them in the FBX file
  where you can't access them if you need to.
  Set the Include Motion to **Current Pose** and tick **Delete Hidden Faces**.

.. image:: images/ex1_export_fbx.jpg

- In Blender and with a new Blend file, you may need to delete the default cube.
  Press **N** to show the tools panel and select the **CC3** Tab.
  Select the **Lighting** option and then import the character by pressing the **Import Character** button under the *Render / Quality* header.
  Navigate to where you saved the exported the character from Character Creator, select the file and click the import button.

.. image:: images/ex1_import_panel.jpg

- This will import the character, set up the materials and set up some lighting similar to Character Creators default lighting to better view the character in the viewport.
  You can hide the Armature if it's getting in the way.

.. image:: images/ex1_import_char.jpg

- Expand the **Materials and Build Settings** panel.
  Here you can change the way the add-on builds the materials,
  quickly adjust the alpha blend settings on any object and material and change any of the material parameters.
  Full details of the material settings can be found here: :doc:`materials`.

.. image:: images/ex1_materials_panel.jpg

- The add-on attempts to identify which object is the hair mesh by looking for keywords in the object and material names.
  The hair hint and scalp hint fields contain the keywords the add-on searches for.
  If the add-on finds the hair object and scalp material it will fill in the respective fields.
  If it doesn't you choose the hair object by hand and then select the scalp material.
  If there is no obvious scalp material or there is only one material in the hair mesh, leave the scalp material field blank.

- In the **Material Setup** section you can quickly set the alpha blend settings for the materials in the active object, as well as the back face culling method.
  Select the sunglasses in the viewport and try changing the alpha blend settings on the lens material of the sunglasses. Glass lenses and the like are best set to alpha **Blend**, whereas clothing and hair are best set to alpha **Hashed**.

.. image:: images/ex1_glasses_mat.jpg

- Finally there is the **Adjust Parameters** section. Here are all the parameters the add-on uses to set up the materials. Each one can be adjusted and the
  materials will update in real time as you change the parameter sliders. This section can be rather long so remember to scroll down through it.
  Have a play with the parameters to see how they affect the materials.

.. image:: images/ex1_params.jpg
  :width: 600