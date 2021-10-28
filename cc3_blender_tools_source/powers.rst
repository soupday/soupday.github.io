.. _Exponentiation: https://en.wikipedia.org/wiki/Exponentiation
.. _Power Law: https://en.wikipedia.org/wiki/Power_law
.. _Gamma Correction: https://en.wikipedia.org/wiki/Gamma_correction
..
    Mathematical symbol reference https://oeis.org/wiki/List_of_LaTeX_mathematical_symbols

~~~~~~~~~~~~~~~~~~~~~~~~
Notes on Power Functions
~~~~~~~~~~~~~~~~~~~~~~~~


Introduction
============

Bitmaps, be they single channel greyscale or RGB are essentially an array of values where each value is between 0 and 1.

.. Figure:: images/head_roughness_g0_sm.png
    :align: center
    :alt: Greyscale Roughness Map

    *Greyscale Head Roughness Map*
    
In a shader, when we use a parameter such as 'Roughness Power', this parameter is used in an operation which takes a value :math:`b` from the bitmap and raises it to the power of the parameter :math:`n` i.e. :math:`b^n` (here :math:`b` is referred to as the *base* and :math:`n` as the *exponent*.  This operation is usually referred to as `Exponentiation`_ or a `Power Law`_.

Blender uses the Math->Power 'Converter' type shadernode (light blue) to do this  *(shown below for illustration)*.

.. Figure:: images/blender_power_node.png
    :align: center
    :alt: Converter Node: Math (Power)

    *Converter Node: Math (Power)*

This type of operation is known as `Gamma Correction`_ where 'gamma' (:math:`\gamma`) is the *exponent*, :math:`V_{\mathrm{in}}` is the *base* (i.e. the input bitmap) and :math:`A` is a constant of proportionality which gives Gamma Corrected :math:`V_{\mathrm{out}}` (i.e. the output bitmap) in the expression:

.. math::

    V_{\mathrm{out}} = A V_{\mathrm{in}}^{\gamma}

|

Exponent Effects
================

When the *base* value you are raising to a power is between 0 and 1 (as is the case with a bitmap), the result can never be lower then 0 or greater than 1.  Thus all the values in a bitmap can be safely *tuned* in a non-linear manner by only varying the *exponent*.

.. |x02| image:: /images/x^0.2.png
    :width: 300 px

.. |e02| image:: /images/_exponent_0.2.png
    :width: 300 px

.. |x1| image:: /images/x^1.png
    :width: 300 px

.. |e1| image:: /images/_exponent_1.png
    :width: 300 px

.. |x2| image:: /images/x^2.png
    :width: 300 px

.. |e2| image:: /images/_exponent_2.png
    :width: 300 px

.. |x5| image:: /images/x^5.png
    :width: 300 px

.. |e5| image:: /images/_exponent_5.png
    :width: 300 px

.. admonition:: Important

    The value of the *exponent* can have a dramatic effect on the bitmap.  Consider the examples below:

    When the *exponent* is 0.2 (:math:`y = x^{0.2}` i.e. the *quintic root* :math:`x^{1/5}`) smaller values are amplified much more than the higher values (with a roughness map, this would mean that the smoother areas are made somewhat rougher; with a RGB image, the darker areas would be significantly lightened)

    When the *exponent* is 1 (:math:`y = x^{1}` :math:`\equiv` :math:`y = x`) this is the neutral case where the operation makes no changes to the bitmap.

    |x02| |x1|
    
    |e02| |e1|

    When the *exponent* is above 1 but still small, we can see a slight reduction in lower end values and a slight increase in higher end values e.g with :math:`y = x^{2}`.

    As the *exponent* becomes higher (e.g with :math:`y = x^{5}`) we observe a very significant reduction of all but the highest end values (with a roughness map this would smooth out all but the roughest areas; with a RGB image, the lighter areas would be significantly darkened)

    |x2| |x5|

    |e2| |e5|

    The value of the *exponent* should therefore be adjusted carefully.


