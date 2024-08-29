# Hazelita

我挺喜欢 微软数学 和 Photomath 这两款软件的。应对那些还不算太复杂的数学运算，能给出如此详尽的过程，绝对在许多人的数学学习道路上起了很大帮助作用吧。我也挺喜欢 Wolfram Alpha / Mathematica，毕竟强大就是硬道理。

但是这两者的缺点很严重。如果我是在家里，那这些软件我可以无障碍随便使用。但是考虑到高中生大多数时间都在学校，因此能够在学校的电脑上稳定流畅运行的软件，就显得如此必要了。刚才提及的软件，前者主要运行在手机上——显然地，在学校里并不具备能够使用手机的条件。而至于后者……首先是 ~~犯下 Premium 之罪的~~ Wolfram Alpha——并不是说我不支持正版，而是真不知道在中国大陆如何购买，而且网络环境并不总是稳定；其次是 Mathematica，太大了，学校的电脑根本装不下！再加上部分学校的电脑有硬性的冰点还原等一系列恶心人的操作，所以软件必须易于部署，即装即用。

基于此，我想开发一款 **适用于教学环境的 CAS 计算器**。我准备基于 PyQt 和 SymPy 进行开发。~~绝对不是因为我只会 Python~~

它当然不是 SymPy 的 GUI 套壳。我想将它做成一个底层为 SymPy 的高中数学套件。比如说它可以解导数大题并生成过程，只是计算的时候调用 SymPy；但是包括对题目的思考分析，以及过程的输出，都是由 Hazelita 的算法得出的 😎

~~不过我现在既不会 PyQt 也不会 SymPy，所以开发周期可能无限期延长~~
