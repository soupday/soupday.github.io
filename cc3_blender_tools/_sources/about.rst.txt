~~~~~~~
 About
~~~~~~~

This add-on is primarily for importing and automatically setting up materials for Character Creator 3 and iClone character exports.

.. image:: images/cc3_about.jpg

Using Blender in the Character Creator 3 pipeline can often feel like hitting a brick wall.
Potentially spending hours with the import settings and setting up the material textures and shader node setup by hand.

This add-on aims to reduce that time spent getting characters into Blender down to just a few seconds and
make use of as many of the exported textures as possible so that character artists can work in the highest quality possible using Blender.

As well as the materials, this add-on can also set up and enable cloth physics on any clothing or hair meshes that have PhysX weight maps.

How it works
============

The character exports from CC3 and iClone have a very rigid naming structure. All objects and materials have unique names and the textures
for these materials are stored in folders and named after the object and material names. Thus textures for each
material can be easily discovered without the need for deep recursive scans for texture files.

The add-on then
reconstructs the material nodes, for each object and material, using these textures and the material setup parameters
as needed.

Installing
==========

- Download the **Source Code (zip)** from the `latest release from Github.com <https://github.com/soupday/cc3_blender_tools/releases>`_
- In Blender go to menu **Edit** -> **Preferences** then select **Add-ons**.
- Click the **Install** button at the top of the preferences window and navigate to where you downloaded the zip file, select the file and click **Install Add-on**.
- Activate the add-on by ticking the checkbox next to **Edit** -> **Preferences** then select **Add-ons**
- The add-ons functionality is available through the **CC3** Tab in the tool menu to the right of the main viewport. Press **N** to show the tools if they are hidden.

Removal
=======

- From the menu: **Edit**->**Preferences** then select **Add-ons**
- In the search box search **All** add-ons for **"CC3 Tools"**
- Deactivate the add-on by unticking the checbox next to **Edit**->**Preferences** then select **Add-ons**.
- Then click the **Remove** button.

Updating
========

- Remove the current version of the add-on by following the remove instructions above.
- Follow the installation instructions, above, to install the new version.