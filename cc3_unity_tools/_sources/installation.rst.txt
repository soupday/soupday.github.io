..
    all external links referenced here
.. _git repository: https://github.com/soupday/
.. _git URL: https://github.com/soupday/cc3_unity_tools_HDRP.git
.. _latest release: https://github.com/soupday/cc3_unity_tools_HDRP/releases/
.. _Unity: https://unity.com/
.. _Reallusion: https://www.reallusion.com/
.. _7zip: https://www.7-zip.org/
.. _git for windows: https://github.com/git-for-windows/git/releases/tag/v2.32.0.windows.2

.. _HDRP Repository: https://github.com/soupday/cc3_unity_tools_HDRP/
.. _HDRP Latest Release: https://github.com/soupday/cc3_unity_tools_HDRP/releases/
.. _URP Repository: https://github.com/soupday/cc3_unity_tools_URP
.. _URP Latest Release: https://github.com/soupday/cc3_unity_tools_URP/releases/
.. _3D Repository: https://github.com/soupday/cc3_unity_tools_3D
.. _3D Latest Release: https://github.com/soupday/cc3_unity_tools_3D/releases/


~~~~~~~~~~~~~~
 Installation
~~~~~~~~~~~~~~

Hosting at Github
=================

The tool is hosted in separate Github repositories for the *HDRP*, *URP* and *3D (Built in render pipeline)* render pipelines. It is intended to be installed into **Unity 2020.3 or above** using Unity's internal package manager.  The available repositories are shown below.

.. _HDRP Repository: https://github.com/soupday/cc3_unity_tools_HDRP/
.. _HDRP Latest Release: https://github.com/soupday/cc3_unity_tools_HDRP/releases/
.. _URP Repository: https://github.com/soupday/cc3_unity_tools_URP
.. _URP Latest Release: https://github.com/soupday/cc3_unity_tools_URP/releases/
.. _3D Repository: https://github.com/soupday/cc3_unity_tools_3D
.. _3D Latest Release: https://github.com/soupday/cc3_unity_tools_3D/releases/

.. admonition:: Warning

    Only install **one version** of the tool at a time.  Only use the **package manager** for installation.

.. list-table::
   :widths: 3 3 3
   :header-rows: 1

   * - Pipeline
     - Repository
     - Latest Release  
   * - HDRP
     - `HDRP Repository`_
     - `HDRP Latest Release`_
   * - URP
     - `URP Repository`_
     - `URP Latest Release`_
   * - 3D
     - `3D Repository`_
     - `3D Latest Release`_

To obtain most recent stable version follow the above link to the latest release, and download the **source code.zip** file from there.

Alternatively, you visit the appropriate repository to obtain the latest commit to the main branch by pressing the green 'Code' button and then 'Download Zip' from the dropdown window. Alternatively the code can be cloned directly from github via HTTPS using the 'git URL' which can be copied from the dropdown window (discussed later).

.. image:: images/code_dropdown.png


Installation from .zip file
===========================

.. youtube:: 2CUHkz29X3I

| 

Download the appropriate latest release or latest stable commit (from the code dropdown box). Unpack the .zip file into a **safe + non volatile** directory where you'll be able to store the package files (`7zip`_ is a suitable tool for this, should you lack one).

.. note:: 

    **You must store the package files in a safe place**.  You can make a *directory* inside your project *directory* (eg '<drive>:/~~/<project directory>/downloaded files') if you wish. 

.. admonition:: Warning
    
    **DO NOT** place the unzipped files into the **/Assets** **/Packages** **/Library** or **/ProjectSettings** directories of your project.

In Unity, open your project and navigate to the 'Package Manager' (*via* **Window -> Package Manager**).

.. image:: images/package_manager.png

Now click the 'Add' button.

.. image:: images/package_add_button.png

And select 'Add package from disk'.

.. image:: images/add_from_disk.png

Navigate to the place where you unpacked the .zip file and select package.json.

.. image:: images/package_select.png

The package manager will now install the tool and will end up looking like this.

.. image:: images/post_install_package.png

The tool is fully installed and ready to be used.  Remember to keep the files you installed from safe. 


Installation from git URL
=========================

.. youtube:: SIBUuT3BfGs

| 

**Pre-requisites**

Packages can be installed into Unity directly from a git repository.

The sole requirement for this is that Unity must be able to find the **git.exe** executable somewhere on your PATH.

If you require a git executable you can install `git for windows`_ (download the 64bit windows installer and accept all the default options when installing).

.. image:: images/git_for_win_ver.png

Please make sure you **restart Unity and Unity Hub** after installing git for windows otherwise you will encounter the following error.

.. image:: images/no_git_exe.png


**Installing from Github**

Open the Unity package manager **Window -> Package Manager**, click the add (+) button and select 'Add package from git URL'.

.. image:: images/add_from_url.png

Copy the URL from the green code dropdown box in the `git repository`_.

.. image:: images/copy_code_dropdown.png

Paste this into the package manager and click 'Add'.  The package manager will now install the tool.

Dependencies
============

The HDRP and URP versions of the tool require minimum versions of the following packages to also be installed in your project.

.. _High Definition RP: https://docs.unity3d.com/Packages/com.unity.render-pipelines.high-definition@10.5/manual/index.html
.. _Universal RP: https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@10.5/manual/index.html

.. list-table::
   :widths: 3 3 3
   :header-rows: 1

   * - Pipeline
     - Package
     - Min. Version  
   * - HDRP
     - `High Definition RP`_
     - 10.5.0 or above.
   * - URP
     - `Universal RP`_
     - 10.5.0 or above.


Removal
=======

.. image:: images/remove.png

Open the Unity package manager (**Window -> Package Manager**) highlight the package that you wish to remove and click the remove button.