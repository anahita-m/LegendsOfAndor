let SessionLoad = 1
let s:so_save = &so | let s:siso_save = &siso | set so=0 siso=0
let v:this_session=expand("<sfile>:p")
silent only
cd ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/hexanome-14/Assets/C\#
if expand('%') == '' && !&modified && line('$') <= 1 && getline(1) == ''
  let s:wipebuf = bufnr('%')
endif
set shortmess=aoO
badd +44 initGame.cs
badd +1 Player.cs
badd +63 term://.//2784:/bin/bash
badd +35 ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/hexanome-14/Assets/Heroes/Hero.cs
badd +73 BoardPosition.cs
badd +196 masterClass.cs
badd +36 term://.//15176:/bin/bash
badd +40 term://.//30129:/bin/bash
badd +177 initializeGameObjects.cs
badd +1 ScreenManager.cs
badd +15 CommandRouter.cs
badd +8 Screen.cs
badd +20 term://.//30104:/bin/bash
badd +19 term://.//26567:/bin/bash
badd +200 term://.//13316:/bin/bash
badd +19 term://.//15142:/bin/bash
badd +22 ~/dotfiles/bashh/.bash_exports
badd +22 ~/dotfiles/bashh/.bash_aliases
badd +103 term://.//15566:/bin/bash
badd +1 ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/hexanome-14/Assets/Interfaces/CommandImplementations/Fight.cs
badd +73 term://.//18306:/bin/bash
badd +22 term://.//19161:/bin/bash
badd +29 genericButtonClickAction.cs
badd +58 term://.//11270:/bin/bash
badd +1 ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/hexanome-14/Assets/Photon/PhotonUnityNetworking/Resources/PhotonServerSettings.asset
badd +1 NetworkController.cs
badd +1 term://.//13825:/bin/bash
badd +1 Lobby.cs
argglobal
%argdel
$argadd initGame.cs
set stal=2
edit Player.cs
set splitbelow splitright
wincmd _ | wincmd |
vsplit
1wincmd h
wincmd _ | wincmd |
split
1wincmd k
wincmd w
wincmd w
wincmd _ | wincmd |
split
1wincmd k
wincmd w
wincmd t
set winminheight=0
set winheight=1
set winminwidth=0
set winwidth=1
exe '1resize ' . ((&lines * 14 + 12) / 25)
exe 'vert 1resize ' . ((&columns * 41 + 42) / 85)
exe '2resize ' . ((&lines * 7 + 12) / 25)
exe 'vert 2resize ' . ((&columns * 41 + 42) / 85)
exe '3resize ' . ((&lines * 14 + 12) / 25)
exe 'vert 3resize ' . ((&columns * 43 + 42) / 85)
exe '4resize ' . ((&lines * 7 + 12) / 25)
exe 'vert 4resize ' . ((&columns * 43 + 42) / 85)
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
let s:l = 93 - ((11 * winheight(0) + 7) / 14)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
93
normal! 0
wincmd w
argglobal
if bufexists("ScreenManager.cs") | buffer ScreenManager.cs | else | edit ScreenManager.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 7 - ((0 * winheight(0) + 3) / 7)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
7
normal! 032|
wincmd w
argglobal
if bufexists("masterClass.cs") | buffer masterClass.cs | else | edit masterClass.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 145 - ((0 * winheight(0) + 7) / 14)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
145
normal! 0
wincmd w
argglobal
if bufexists("Screen.cs") | buffer Screen.cs | else | edit Screen.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 8 - ((0 * winheight(0) + 3) / 7)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
8
normal! 05|
wincmd w
exe '1resize ' . ((&lines * 14 + 12) / 25)
exe 'vert 1resize ' . ((&columns * 41 + 42) / 85)
exe '2resize ' . ((&lines * 7 + 12) / 25)
exe 'vert 2resize ' . ((&columns * 41 + 42) / 85)
exe '3resize ' . ((&lines * 14 + 12) / 25)
exe 'vert 3resize ' . ((&columns * 43 + 42) / 85)
exe '4resize ' . ((&lines * 7 + 12) / 25)
exe 'vert 4resize ' . ((&columns * 43 + 42) / 85)
tabedit ~/Documents/Mcgill/5th-year/fall-sem/andor/f2019-hexanome-14/hexanome-14/Assets/Interfaces/CommandImplementations/Fight.cs
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
exe '1resize ' . ((&lines * 12 + 12) / 25)
exe '2resize ' . ((&lines * 9 + 12) / 25)
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
let s:l = 1 - ((0 * winheight(0) + 6) / 12)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
1
normal! 0
wincmd w
argglobal
if bufexists("genericButtonClickAction.cs") | buffer genericButtonClickAction.cs | else | edit genericButtonClickAction.cs | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
silent! normal! zE
let s:l = 15 - ((0 * winheight(0) + 4) / 9)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
15
normal! 020|
wincmd w
exe '1resize ' . ((&lines * 12 + 12) / 25)
exe '2resize ' . ((&lines * 9 + 12) / 25)
tabedit Lobby.cs
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
exe '1resize ' . ((&lines * 20 + 12) / 25)
exe '2resize ' . ((&lines * 1 + 12) / 25)
argglobal
if bufexists("term://.//13825:/bin/bash") | buffer term://.//13825:/bin/bash | else | edit term://.//13825:/bin/bash | endif
setlocal fdm=manual
setlocal fde=0
setlocal fmr={{{,}}}
setlocal fdi=#
setlocal fdl=0
setlocal fml=1
setlocal fdn=20
setlocal fen
let s:l = 20 - ((19 * winheight(0) + 10) / 20)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
20
normal! 0
wincmd w
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
let s:l = 1 - ((0 * winheight(0) + 0) / 1)
if s:l < 1 | let s:l = 1 | endif
exe s:l
normal! zt
1
normal! 0
wincmd w
2wincmd w
exe '1resize ' . ((&lines * 20 + 12) / 25)
exe '2resize ' . ((&lines * 1 + 12) / 25)
tabnext 3
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
