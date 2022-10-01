

function e=boxdwle2d()

d2 = [

4	1.677949	10329	1479	0	8850	0.856810921
4	1.650535	10550	1347	0	9203	0.872322275
4	1.655076	10692	1291	0	9401	0.879255518
4	1.654937	10699	1372	0	9327	0.871763716
4	1.662664	10517	1446	0	9071	0.86250832
5	1.705727	10538	2051	0	8487	0.805371038
5	1.695899	10716	1993	0	8723	0.814016424
5	1.681701	10637	1943	0	8694	0.817335715
5	1.706148	10741	1887	0	8854	0.824318034
5	1.695962	10785	1767	0	9018	0.836161335
6	1.770347	10579	3048	0	7531	0.71188203
6	1.756668	10451	2961	0	7490	0.71667783
6	1.766278	10633	2865	0	7768	0.730555817
6	1.76433	10585	2923	0	7662	0.723854511
6	1.755712	10579	3053	0	7526	0.711409396
8	1.840403	10532	4664	0	5868	0.557159134
8	1.843568	10497	4635	0	5862	0.55844527
8	1.852588	10553	4684	0	5869	0.556145172
8	1.83867	10590	4590	0	6000	0.566572238
8	1.858081	10551	4540	0	6011	0.569709032
10	1.901833	10626	5776	0	4850	0.45642763
10	1.906661	10473	5871	0	4602	0.43941564
10	1.898883	10596	5861	0	4735	0.446866742
10	1.905597	10453	5826	0	4627	0.442648044
10	1.90486	10608	5829	0	4779	0.45050905
15	1.953714	10632	8164	32	2436	0.229119639
15	1.936492	10776	8126	12	2638	0.244803267
15	1.948277	10443	8192	20	2231	0.213635928
15	1.96158	10691	7936	24	2731	0.255448508
15	1.960728	10778	7913	30	2835	0.263035814
20	1.938466	10728	9491	19	1218	0.113534676
20	1.936705	10517	9569	55	893	0.084910145
20	1.936704	10587	9436	23	1128	0.106545764
20	1.947531	10824	9582	32	1210	0.111788618
20	1.934911	10587	9528	51	1008	0.095211108
25	1.869833	10567	10017	60	490	0.046370777
25	1.86758	10522	10070	65	387	0.03678008
25	1.87848	10673	10149	100	424	0.039726412
25	1.867916	10486	10052	90	344	0.032805646
25	1.87481	10611	10218	86	307	0.02893224

];


d2000 = [

4	1.269378	10598	1332	0	9266	0.874315909
4	1.391735	10555	1249	0	9306	0.881667456
4	1.275732	10589	1185	0	9404	0.888091416
4	1.216919	10492	1325	0	9167	0.873713305
4	1.230802	10566	1416	0	9150	0.865985236
5	1.388157	10771	1871	0	8900	0.826292823
5	1.3712	10454	2237	0	8217	0.786014923
5	1.417691	10497	2107	0	8390	0.799275984
5	1.312018	10661	1971	0	8690	0.815120533
5	1.393685	10547	2114	0	8433	0.799563857
6	1.415274	10824	3072	0	7752	0.716186253
6	1.449376	10600	3423	0	7177	0.677075472
6	1.681349	10468	3403	0	7065	0.674914024
6	1.522235	10694	3424	0	7270	0.67982046
6	1.577318	10556	3409	0	7147	0.677055703
8	1.569314	10627	5422	0	5205	0.489790157
8	1.758916	10453	5812	0	4641	0.443987372
8	1.629898	10769	5306	0	5463	0.507289442
8	1.576635	10585	5673	0	4912	0.464052905
8	1.671019	10593	5547	0	5046	0.476352308
10	1.741692	10581	7074	1	3506	0.331348644
10	1.819118	10517	7168	0	3349	0.318436817
10	1.816366	10572	7294	4	3274	0.309685963
10	1.702735	10546	7109	1	3436	0.325810734
10	1.787032	10664	7231	0	3433	0.321924231
15	1.91978	10644	9687	20	937	0.088030815
15	1.918604	10513	9546	10	957	0.091030153
15	1.985269	10744	9543	8	1193	0.111038719
15	1.938494	10454	9411	7	1036	0.099100823
15	1.871996	10821	9248	5	1568	0.144903429

20	1.960108	10713	10492	38	183	0.01708205
20	1.961917	10700	10567	36	97	0.009065421
20	1.96234	10501	10449	29	23	0.002190268
20	1.975172	10846	10719	25	102	0.009404389
20	1.975981	10487	10412	48	27	0.002574616

];


d2000g5 = [

4	1.686863	10729	7140	0	3589	0.334513934
4	1.699205	10558	7279	0	3279	0.310570184
4	1.717733	10467	7317	0	3150	0.30094583
4	1.612817	10614	7186	0	3428	0.322969663
4	1.615236	10631	7058	0	3573	0.336092559
5	1.775818	10673	8301	0	2372	0.222243043
5	1.778279	10419	8448	0	1971	0.189173625
5	1.792184	10632	8481	0	2151	0.20231377
5	1.911093	10450	8425	0	2025	0.193779904
5	1.827013	10435	8283	0	2152	0.206229037
6	1.910653	10551	9430	0	1121	0.106245853
6	1.8677	10545	9331	0	1214	0.115125652
6	1.974902	10634	9557	0	1077	0.101278917
6	1.90953	10519	9478	0	1041	0.09896378
6	1.857731	10505	9436	0	1069	0.101761066
8	1.945442	10565	10537	6	22	0.002082347
8	1.956421	10620	10558	5	57	0.005367232
8	1.926778	10617	10490	3	124	0.011679382
8	1.946143	10550	10460	7	83	0.007867299
8	1.887847	10458	10369	7	82	0.007840887

];

d2g5 = [

4	1.662865	10404	6346	0	4058	0.390042291
4	1.633784	10633	6025	0	4608	0.433367817
4	1.643379	10718	6098	0	4620	0.431050569
4	1.640434	10670	6084	0	4586	0.429803187
4	1.643916	10532	6053	0	4479	0.425275351
5	1.70159	10651	6793	0	3858	0.36221951
5	1.726685	10391	6994	0	3397	0.326917525
5	1.713706	10736	6923	0	3813	0.355160209
5	1.702004	10698	7008	0	3690	0.344924285
5	1.697438	10877	6809	0	4068	0.374000184
6	1.792962	10605	8179	0	2426	0.228760019
6	1.792731	10576	8110	0	2466	0.23316944
6	1.785383	10611	8149	0	2462	0.232023372
6	1.794964	10644	8233	0	2411	0.226512589
6	1.795192	10471	8107	0	2364	0.225766402
8	1.812232	10522	9505	0	1017	0.096654628
8	1.832434	10653	9611	0	1042	0.097812823
8	1.817987	10442	9520	0	922	0.088297261
8	1.826233	10608	9642	0	966	0.091063348
8	1.8264	10698	9572	0	1126	0.105253318
10	1.779396	10456	10061	0	395	0.037777353
10	1.791989	10595	10039	0	556	0.052477584
10	1.799371	10589	10175	0	414	0.039097176
10	1.794817	10704	10195	1	508	0.047458894
10	1.782719	10597	10110	0	487	0.045956403


];




figure;
hold on;


h3=boxplot(1-d2000(:,7)+0.2,d2000(:,1), 'Positions', d2000(:,1), 'symbol', '.',  'Labels', d2000(:,1));
h4=boxplot(1-d2000g5(:,7),d2000g5(:,1), 'Positions', d2000g5(:,1), 'symbol', '.', 'colors' , [0.466 0.674 0.188],  'Labels', d2000g5(:,1));
h5=boxplot(1-d2g5(:,7)+0.05,d2g5(:,1), 'Positions', d2g5(:,1), 'symbol', '.',  'colors' , 'k' ,'Labels', d2g5(:,1));
h2=boxplot(1-d2(:,7)+0.2,d2(:,1), 'Positions', d2(:,1), 'symbol', '.', 'colors' , [0.85 0.325 0.098],  'Labels', d2(:,1));
ylabel("Proportion of Surviving Axons");
xlabel("Mitochondria %");
ylim([0, 1]);
xlim([0,22]);
hold off;
legend([h2(5,1),h3(5,1),h5(5,1),h4(5,1)], {'P_m= 20 um s^{-1} Mito_{glia}= 10%', 'P_m= 200 um s^{-1} Mito_{glia}= 10%', 'P_m= 20 um s^{-1} Mito_{glia}= 5%' , 'P_m= 200 um s^{-1} Mito_{glia}= 5%'});


end