program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
function US0_0(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_1: TUS0;
begin
  Result.tag := 1; 
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v60: LongInt;
  v69: AnsiString;
  v92: LongInt;
  v94: AnsiString;
  v141: LongInt;
  v143: AnsiString;
  v775: Boolean;
  v776: Int64;
  v777: LongInt;
  v781: Boolean;
  v778: Boolean;
  v779: Boolean;
  v784: TUS0;
  v808: AnsiString;
  v795: LongInt;
  v809: AnsiString;
  v810: Boolean;
  v811: Int64;
  v812: LongInt;
  v816: Boolean;
  v813: Boolean;
  v814: Boolean;
  v819: TUS0;
  v821: AnsiString;
  v820: LongInt;
  v822: AnsiString;
  v823: Boolean;
  v824: Int64;
  v825: LongInt;
  v829: Boolean;
  v826: Boolean;
  v827: Boolean;
  v832: TUS0;
  v834: AnsiString;
  v833: LongInt;
  v835: AnsiString;
  v836: Boolean;
  v837: Int64;
  v838: LongInt;
  v842: Boolean;
  v839: Boolean;
  v840: Boolean;
  v845: TUS0;
  v847: AnsiString;
  v846: LongInt;
begin
  v0 := 'ff';
  v60 := StrToInt(#36 + v0);
  Writeln(v60);
  v69 := '1011';
  v92 := StrToInt(#37 + v69);
  Writeln(v92);
  v94 := '-42';
  v141 := StrToInt(v94);
  Writeln(v141);
  v143 := ' 123 ';
  v775 := (StrToInt64Def(Trim(v143), 0) = StrToInt64Def(Trim(v143), 1));
  v776 := StrToInt64Def(Trim(v143), 0);
  v777 := LongInt(v776);
  if v775 then begin
      v778 := v776 >= (-2147483648);
      if v778 then begin
          v779 := v776 <= 2147483647;
          v781 := v779;
      end else begin
          v781 := False;
      end;
  end else begin
      v781 := False;
  end;
  if v781 then begin
      v784 := US0_0(v777);
  end else begin
      v784 := US0_1;
  end;
  case v784.tag of
      1: begin
          v808 := 'none';
          Writeln(v808);
      end;
      0: begin
          v795 := v784.c0_0;
          Writeln(v795);
      end;
  end;
  v809 := '12x';
  v810 := (StrToInt64Def(Trim(v809), 0) = StrToInt64Def(Trim(v809), 1));
  v811 := StrToInt64Def(Trim(v809), 0);
  v812 := LongInt(v811);
  if v810 then begin
      v813 := v811 >= (-2147483648);
      if v813 then begin
          v814 := v811 <= 2147483647;
          v816 := v814;
      end else begin
          v816 := False;
      end;
  end else begin
      v816 := False;
  end;
  if v816 then begin
      v819 := US0_0(v812);
  end else begin
      v819 := US0_1;
  end;
  case v819.tag of
      1: begin
          v821 := 'none';
          Writeln(v821);
      end;
      0: begin
          v820 := v819.c0_0;
          Writeln(v820);
      end;
  end;
  v822 := '';
  v823 := (StrToInt64Def(Trim(v822), 0) = StrToInt64Def(Trim(v822), 1));
  v824 := StrToInt64Def(Trim(v822), 0);
  v825 := LongInt(v824);
  if v823 then begin
      v826 := v824 >= (-2147483648);
      if v826 then begin
          v827 := v824 <= 2147483647;
          v829 := v827;
      end else begin
          v829 := False;
      end;
  end else begin
      v829 := False;
  end;
  if v829 then begin
      v832 := US0_0(v825);
  end else begin
      v832 := US0_1;
  end;
  case v832.tag of
      1: begin
          v834 := 'none';
          Writeln(v834);
      end;
      0: begin
          v833 := v832.c0_0;
          Writeln(v833);
      end;
  end;
  v835 := '+7';
  v836 := (StrToInt64Def(Trim(v835), 0) = StrToInt64Def(Trim(v835), 1));
  v837 := StrToInt64Def(Trim(v835), 0);
  v838 := LongInt(v837);
  if v836 then begin
      v839 := v837 >= (-2147483648);
      if v839 then begin
          v840 := v837 <= 2147483647;
          v842 := v840;
      end else begin
          v842 := False;
      end;
  end else begin
      v842 := False;
  end;
  if v842 then begin
      v845 := US0_0(v838);
  end else begin
      v845 := US0_1;
  end;
  case v845.tag of
      1: begin
          v847 := 'none';
          Writeln(v847);
      end;
      0: begin
          v846 := v845.c0_0;
          Writeln(v846);
      end;
  end;
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
