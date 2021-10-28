.. |br2| raw:: html

   <br /><br />

.. |br| raw:: html

   <br />


######
 Skin 
######

**************
Skin Materials
**************

.. image:: images/selected_head_obj.png
    :width: 400
    :align: center

.. |mtpr| image:: /images/material_properties.png

|

All skin material parameters are accessible in the **Material Parameters** dropdown of the tool, by selecting the **CC3_Base_Body** object (in *Object Mode*) and then selecting the appropriate material in the *Material Properties* tab |mtpr| of the *properties* pane. 

.. |mat_sel_img|
    image:: images/skin_material_selection.png

.. |mat_sel_txt_a| replace:: 
    *Skin Releated Materials Are:*

.. |mat_sel_txt_b| replace:: 
    **Std_Skin_Head**

.. |mat_sel_txt_c| replace:: 
    **Std_Skin_Body**

.. |mat_sel_txt_d| replace:: 
    **Std_Skin_Arm**

.. |mat_sel_txt_e| replace:: 
    **Std_Skin_Leg**

.. list-table::
    :widths: 2 3
    :header-rows: 0

    * - |mat_sel_img|
      - |mat_sel_txt_a|
        |br2|
        |mat_sel_txt_b|
        |br|
        |mat_sel_txt_c|
        |br|
        |mat_sel_txt_d|
        |br|
        |mat_sel_txt_e|                    


.. image:: images/material_parameters_pane_s.png
    :align: right

The *Material Parameters* pane of the CC3 tool will then be updated with the available settings for the *Selected Material*.

Depending on which material is selected, the exposed shader parameters may differ. All of the potential differences are discussed below.

These parameters can be adjusted simultaneously as :ref:`linked materials<Linked Materials>`.

|br2|

***************
Skin Parameters
***************

**Base Color**

This section deals with ambient occlusion strength for the mouth, nostrils and lips.

..
    Base Color - Begin =========================================================================

.. |im1| 
    image:: images/mat_param_skin_head_base_col.png

.. |tx1a| replace:: 
    *AO Strength* - (Multiply) Blending factor of the ambient occlusion overlay. Blending factor is discussed :ref:`here<Notes on Color Mixing>`

.. |tx1b| replace::
    *Mouth/Nostrils/Lips AO (Head Specific)* - *Exponent* to control the strength of the ambient occlusion for each of the individual cavities (lips refers to the inner lip lining). See :ref:`these notes<Notes on Power Functions>` on the effects of exponents.

.. |tx1c| replace::
    *Color Blend (Head Specific)* - (Overlay) Blending factor of the AO overlay with the base skin texture.

.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im1|
     - |tx1a|
       |br2|
       |tx1b|
       |br2|
       |tx1c|

..
    Base Color - End ===========================================================================

|

**Surface**

This section controls specular reflection and roughness of the character's skin.

*Surface (Head Specific)*

..
    Surface - Begin ============================================================================

.. |im2|
    image:: images/mat_param_skin_head_surface.png

.. |tx2a| replace::
    *Specular scale* - Base effect strength of the masked specular map.

.. |tx2b| replace::
    *Roughness Power* - *Exponent* to control the base strength of the roughness map.

.. |tx2c| replace::
    *Roughness Min/Max* - These settings will rescale the Roughness Map + applied Roughness Power (which will have a min of 0 and max of 1) to the min and max settings you may wish to specify.  This is useful for narrowing the difference between the most and least rough parts of the model, where you can also fine tune the whole value range up and down as you see fit see these :ref:`notes<Notes on Remapping Functions>` for more details.

.. |tx2d| replace::
    *Micro Roughness Mod* - Overall value *added* to to each of the location specific roughness mods (below).

.. |tx2e| replace::
    *Roughness Mod (specific)* - Roughness map *multiplier* (always has the  above *micro roughness mod* added to it) For the specific locations: Ear, Neck, Chin, Forehead, Upper Lip, Cheek, Nose, Mouth, Upper Lid & Inner Lid (these locations are predefined by masks exported with the character).

.. |tx2f| replace::
    *Unmasked Roughness Mod* - Non specific roughness map *multiplier* for unmasked areas.


.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im2|
     - |tx2a|
       |br2|
       |tx2b|
       |br2|
       |tx2c|
       |br2|
       |tx2d|
       |br2|
       |tx2e|
       |br2|
       |tx2f|

..
    Surface - End ==============================================================================

*Surface (non-Head)*

..
    Surface (non-Head) - Begin =================================================================

.. |im3|
    image:: images/mat_param_skin_nonhead_surface.png

.. |tx3a| replace::
    *Surface (non-Head) differences:*

.. |tx3b| replace::
    *Roughness Masking* - Whilst the head has multiple masks to define the various areas where specific roughness could be applied, all of the non-head shaders each employ a single mask consisting of 4 channels (RGBA) which can be adjusted individually.  

.. |tx3C| replace::
    *NB* - Only if the exported RGBA mask has data in it then the masked area roughness can be adjusted (on a per-chennel basis); otherwise no effects will be observed.

.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im3|
     - |tx3a|
       |br2|
       |tx3b|
       |br|
       |tx3c|
..
    Surface (non-Head) - End ===================================================================

|

**Subsurface**

*Subsurface (Head Specific)*

..
    Subsurface - Begin ========================================================================

.. |im4|
    image:: images/mat_param_skin_head_sub_surface.png

.. |im4a|
    image:: images/surface_subsurface_radii.png

.. |tx4a| replace::
    *Subsurface Falloff & Subsurface Radius* - These are combined to give a vector which controls the subsurface scattering radius for each color, thus:

.. _SSS in the Eevee render engine: https://docs.blender.org/manual/en/latest/render/eevee/limitations.html#eevee-limitations-sss

.. |tx4b| replace::
    *'Subsurface Radius Vector'* in the material surface properties.  This is used to bypass limitiations of `SSS in the Eevee render engine`_.

.. |tx4c| replace::
    *Subsurface Scale* - This is a multiplier that effectively represents the opacity of the subsurface scattering.

.. |tx4d| replace::
    *Scatter Scale (Specific)* - Additional (cumulative with the subsurface scale) scattering multiplier for each specific area. As with roughness (above), the specific locations: Ear, Neck, Chin, Forehead, Upper Lip, Cheek, Nose, Mouth, Upper Lid & Inner Lid are predefined by (the same) masks exported with the character.

.. |tx4e| replace::
     *Unmasked Scatter Scale* - Non specific scattering multiplier for unmasked areas.

.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im4|
     - |tx4a|
       |br2|
       |im4a|
       |br2|
       |tx4b|
       |br2|
       |tx4c|  
       |br2|
       |tx4d| 
       |br2|
       |tx4e| 

..
    Subsurface - End ==========================================================================

*Subsurface (non-Head)*

..
    Subsurface (non-Head) - Begin =============================================================

.. |im5|
    image:: images/mat_param_skin_nonhead_sub_surface.png

.. |tx5a| replace::
    *Subsurface (non-Head) differences:*

.. |tx5b| replace::
    *Scatter Scale* - As with roughness (above), the non-head shaders use a general RGBA mask to define where subsurface scattering may be applied.

.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im5|
     - |tx5a|
       |br2|
       |tx5b|       

..
    Subsurface (non-Head) - End ===============================================================

|

**Normals**

..
    Normals - Begin ============================================================================

.. |im6|
    image:: images/mat_param_skin_head_normals.png

.. |tx6a| replace::
    *Normal Strength* - The *Tangent Space* strength of the final normal map (after blending with the normal blend and micro-normal maps.

.. |tx6b| replace::
    *Normal Blend* - The Extent of overlay blending of the base normal map and the normal blend map.

.. |tx6c| replace::
    *Micro Normal Strength* - The (masked) extent of overlay blending of the micro normal with previously blended normal + normal blend map.

.. |tx6d| replace::
    *NB* - Normal maps are overlay blended in the following order: 
    
.. |tx6e| replace::
    **Base Normal Map** -> **Normal Blend Map** -> **Micro Normal Map**

.. |tx6f| replace::
    *Micro Normal Tiling* - UV scaling of the micro normal map.

.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im6|
     - |tx6a|
       |br2|
       |tx6b|
       |br2|
       |tx6c|
       |br2|
       |tx6d|
       |br|
       |tx6e|
       |br2|
       |tx6f|

..
    Normals - End ==============================================================================

|

**Emission**

..
    Emission - Begin ===========================================================================

.. |im7|
    image:: images/mat_param_skin_head_emission.png

.. |tx7a| replace::
    *Emission Color* - Color multiplied with an available emission map.

.. |tx7b| replace::
    *Emission Strength* Value by which the color*emission map is multiplied to give the final emission map.

.. list-table::
   :widths: 2 3
   :header-rows: 0

   * - |im7|
     - |tx7a|
       |br2|
       |tx7b|
       
..
    Emission - End =============================================================================
