.. _Unity: https://unity.com/
.. _Reallusion: https://www.reallusion.com/

~~~~~~~
 About
~~~~~~~

Welcome to the `Unity`_ import and auto setup tool for **Character Creator 3** and **iClone 7** from `Reallusion`_.

.. image:: images/preview_scene.png

This is a fully featured tool to take exports from CC3/iClone and set them up in Unity with complete visual fidelity.

The tool can produce characters of the highest visual quality using custom Shader graph shaders.
Additionally, more performance focussed characters can be produced using simpler shaders with a minimal loss of visual quality. 

How it works
============

Character exports from CC3 and iClone can be dragged into Unity, the import tool can then be opened and the character processed with a single click.

For full details of the workflow, see the :ref:`Usage <Usage>` section of this documentation.


Obtaining the Tool
==================

.. _HDRP: https://docs.unity3d.com/Manual/high-definition-render-pipeline.html
.. _URP: https://docs.unity3d.com/Manual/universal-render-pipeline.html
.. _3D: https://docs.unity3d.com/Manual/built-in-render-pipeline.html

The tool is currently available for each of the 3 render pipelines in Unity, `HDRP`_ (High Definition Render Pipeline), `URP`_ (Universal Render Pipeline) and `3D`_ (the default built in render pipeline).

The tool can be installed using Unity's internal package manager from either the *Main* branch of the appropriate git repository, or via download of the .zip of the latest release.  The links to the repository and latest releases are shown below.

.. _HDRP Repository: https://github.com/soupday/cc3_unity_tools_HDRP/
.. _HDRP Latest Release: https://github.com/soupday/cc3_unity_tools_HDRP/releases/
.. _URP Repository: https://github.com/soupday/cc3_unity_tools_URP
.. _URP Latest Release: https://github.com/soupday/cc3_unity_tools_URP/releases/
.. _3D Repository: https://github.com/soupday/cc3_unity_tools_3D
.. _3D Latest Release: https://github.com/soupday/cc3_unity_tools_3D/releases/

.. list-table::
   :widths: 3 3 3
   :header-rows: 1

   * - Pipeline
     - Repository
     - Latest Release
   * - `HDRP`_
     - `HDRP Repository`_
     - `HDRP Latest Release`_
   * - `URP`_
     - `URP Repository`_
     - `URP Latest Release`_
   * - `3D`_
     - `3D Repository`_
     - `3D Latest Release`_

This process is discussed in detail in the :ref:`Installation <Installation>` section of this documentation.

**Removal**

Unity's internal package manager allows the simple and safe removal of the tool.


**Updating**

Simply remove the existing tool as above and install the latest version.


