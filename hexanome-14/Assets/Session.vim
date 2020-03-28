let SessionLoad = 1
let s:so_save = &so | let s:siso_save = &siso | set so=0 siso=0
let v:this_session=expand("<sfile>:p")
silent only
cd ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/hexanome-14/Assets
if expand('%') == '' && !&modified && line('$') <= 1 && getline(1) == ''
  let s:wipebuf = bufnr('%')
endif
set shortmess=aoO
badd +19 del.cs
badd +39 term://.//24970:/bin/bash
badd +24 Screens/fight/FightScreen.cs
badd +54 term://.//26530:/bin/bash
badd +1 Screens/ScreenManager.cs
badd +47 term://.//28057:/bin/bash
badd +144 C\#/Player.cs
badd +56 C\#/Player_click_handler.cs
badd +43 term://.//21439:/bin/bash
badd +25 term://.//22414:/bin/bash
badd +1 C\#/Graph.cs
badd +28 C\#/Node.cs
badd +89 C\#/masterClass.cs
badd +19 C\#/TurnManager.cs
badd +1 C\#/BoardContents.cs
badd +28 term://.//32300:/bin/bash
badd +31 Screens/Screen.cs
badd +47 term://.//5474:/bin/bash
badd +22 Screens/AndorBoardScreen.cs
badd +20 term://.//16513:/bin/bash
badd +20 term://.//20152:/bin/bash
badd +21 term://.//20522:/bin/bash
badd +124 term://.//25170:/bin/bash
badd +20 term://.//18270:/bin/bash
badd +20 term://.//29350:/bin/bash
badd +89 C\#/CustomMatchmakingRoomController.cs
badd +20 term://.//19404:/bin/bash
badd +22 term://.//25984:/bin/bash
badd +49 term://.//23671:/bin/bash
badd +26 term://.//24065:/bin/bash
badd +37 C\#/BoardPosition.cs
badd +61 term://.//25883:/bin/bash
badd +45 C\#/PhotonPlayer.cs
badd +53 C\#/GameSetupController.cs
badd +7910 ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/tags
badd +21 term://.//64000:/bin/bash
badd +30 C\#/PlayerInfo.cs
badd +38 C\#/MenuController.cs
badd +136 Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts/PlayerManager.cs
badd +37 term://.//82480:/bin/bash
badd +1 C\#/AvatarSetup.cs
badd +68 term://.//83813:/bin/bash
badd +21 term://.//85310:/bin/bash
badd +46 Session.vim
badd +23 term://.//86513:/bin/bash
badd +20 term://.//238779:/bin/bash
badd +48 term://.//675400:/bin/bash
badd +48 term://.//248166:/bin/bash
badd +36 term://.//675401:/bin/bash
argglobal
%argdel
$argadd del.cs
set stal=2
edit C\#/BoardContents.cs
set splitbelow splitright
wincmd _ | wincmd |
split
1wincmd k
wincmd w
wincmd t
set winminheight=0
set winheight=1
set winminwidth=0
set winwidth=1
exe '1resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 1resize ' . ((&columns * 85 + 87) / 174)
exe '2resize ' . ((&lines * 23 + 27) / 54)
exe 'vert 2resize ' . ((&columns * 85 + 87) / 174)
argglobal
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 37 - ((22 * winheight(0) + 12) / 24)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
37
normal! 0
wincmd w
argglobal
if bufexists("C\#/Node.cs") | buffer C\#/Node.cs | else | edit C\#/Node.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 1 - ((0 * winheight(0) + 11) / 23)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
1
normal! 0
wincmd w
exe '1resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 1resize ' . ((&columns * 85 + 87) / 174)
exe '2resize ' . ((&lines * 23 + 27) / 54)
exe 'vert 2resize ' . ((&columns * 85 + 87) / 174)
tabedit C\#/Graph.cs
set splitbelow splitright
wincmd _ | wincmd |
split
1wincmd k
wincmd w
wincmd t
set winminheight=0
set winheight=1
set winminwidth=0
set winwidth=1
exe '1resize ' . ((&lines * 1 + 27) / 54)
exe '2resize ' . ((&lines * 49 + 27) / 54)
argglobal
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 122 - ((0 * winheight(0) + 0) / 1)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
122
normal! 0
wincmd w
argglobal
if bufexists("C\#/Player.cs") | buffer C\#/Player.cs | else | edit C\#/Player.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 168 - ((27 * winheight(0) + 24) / 49)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
168
normal! 052|
wincmd w
2wincmd w
exe '1resize ' . ((&lines * 1 + 27) / 54)
exe '2resize ' . ((&lines * 49 + 27) / 54)
tabedit Screens/ScreenManager.cs
set splitbelow splitright
wincmd _ | wincmd |
vsplit
1wincmd h
wincmd w
wincmd t
set winminheight=0
set winheight=1
set winminwidth=0
set winwidth=1
exe 'vert 1resize ' . ((&columns * 83 + 87) / 174)
exe 'vert 2resize ' . ((&columns * 90 + 87) / 174)
argglobal
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 32 - ((25 * winheight(0) + 25) / 51)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
32
normal! 0
wincmd w
argglobal
if bufexists("Screens/Screen.cs") | buffer Screens/Screen.cs | else | edit Screens/Screen.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 31 - ((0 * winheight(0) + 25) / 51)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
31
normal! 05|
wincmd w
exe 'vert 1resize ' . ((&columns * 83 + 87) / 174)
exe 'vert 2resize ' . ((&columns * 90 + 87) / 174)
tabedit C\#/AvatarSetup.cs
set splitbelow splitright
wincmd _ | wincmd |
split
1wincmd k
wincmd _ | wincmd |
vsplit
wincmd _ | wincmd |
vsplit
2wincmd h
wincmd w
wincmd w
wincmd w
wincmd t
set winminheight=0
set winheight=1
set winminwidth=0
set winwidth=1
exe '1resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 1resize ' . ((&columns * 41 + 87) / 174)
exe '2resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 2resize ' . ((&columns * 42 + 87) / 174)
exe '3resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 3resize ' . ((&columns * 0 + 87) / 174)
exe '4resize ' . ((&lines * 23 + 27) / 54)
exe 'vert 4resize ' . ((&columns * 85 + 87) / 174)
argglobal
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 30 - ((12 * winheight(0) + 12) / 24)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
30
normal! 09|
wincmd w
argglobal
if bufexists("C\#/GameSetupController.cs") | buffer C\#/GameSetupController.cs | else | edit C\#/GameSetupController.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 90 - ((10 * winheight(0) + 12) / 24)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
90
normal! 09|
wincmd w
argglobal
if bufexists("C\#/PlayerInfo.cs") | buffer C\#/PlayerInfo.cs | else | edit C\#/PlayerInfo.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 11 - ((0 * winheight(0) + 12) / 24)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
11
normal! 05|
wincmd w
argglobal
if bufexists("C\#/PhotonPlayer.cs") | buffer C\#/PhotonPlayer.cs | else | edit C\#/PhotonPlayer.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 41 - ((7 * winheight(0) + 11) / 23)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
41
normal! 0
wincmd w
exe '1resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 1resize ' . ((&columns * 41 + 87) / 174)
exe '2resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 2resize ' . ((&columns * 42 + 87) / 174)
exe '3resize ' . ((&lines * 24 + 27) / 54)
exe 'vert 3resize ' . ((&columns * 0 + 87) / 174)
exe '4resize ' . ((&lines * 23 + 27) / 54)
exe 'vert 4resize ' . ((&columns * 85 + 87) / 174)
tabnext 2
set stal=1
if exists('s:wipebuf') && getbufvar(s:wipebuf, '&buftype') isnot# 'terminal'
  silent exe 'bwipe ' . s:wipebuf
endif
unlet! s:wipebuf
set winheight=1 winwidth=20 winminheight=1 winminwidth=1 shortmess=filnxtToOFs
let s:sx = expand("<sfile>:p:r")."x.vim"
if file_readable(s:sx)
  exe "source " . fnameescape(s:sx)
endif
let &so = s:so_save | let &siso = s:siso_save
let g:this_session = v:this_session
let g:this_obsession = v:this_session
doautoall SessionLoadPost
unlet SessionLoad
" vim: set ft=vim :
