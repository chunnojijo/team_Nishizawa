Thanks for your purchase of Horizon[ON].



Important Notes:

The included example scenes are set up for gamma and linear color space, please choose the right one for your project (Linear is always recommended if available in your target platform).

In the example scenes you might find a missing script on the main camera, this is the "Post Processing Behaviour" from Unity's "Post Processing Stack" asset. You may want to import it to your project to test Horizon[ON] as it is shown in the demo, or simply remove the missing component. here is the link to the asset:

https://assetstore.unity.com/packages/essentials/post-processing-stack-83912

I wholeheartedly recommend Unity's "Post Processing Stack" and Horizon comes with 2 post processing profiles(linear and gamma) to give the example scene the final polish. 

If you get a warning upon Import of Horizon[ON] about "floating point division by zero at UnityCG.cginc(193) (on d3d11)", this is a Unity Issue and cannot be resolved as it would need a change in UnityCG.cginc on your side(use Unity_SafeNormalize() instead of Normalize())! The warning is harmless though and can be ignored.

If you have issues with shadows not working correctly in the example scene after your first import, please restart Unity.

Lastly, please test Horizon[ON] in a fresh empty project to make sure that any errors you might experience are not coming from Horizon[ON], before you integrate it into an existing project. 



Before you contact me or ask for help in the forum, please read the manual, it has a "frequently asked questions" section and a troubleshooting section as well as an explanation for every element of Horizon[ON]. Also it contains a step by step getting started guide. I don't want to discourage you from posting in the forum, i only want to point out that most questions are answered in the manual. If you still have problems please do not hesitate to post in the forum or write an email to peter@becoming.at. Also feedback is very welcome! If you made yourself familiar with Horizon[ON] i would appreciate an assetstore rating/review. Thank you :)

Please visit the forum thread for news:
http://forum.unity3d.com/threads/horizon-on-make-your-horizons-look-real.259733/ 

