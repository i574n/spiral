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
  v59: LongInt;
  v67: AnsiString;
  v90: LongInt;
  v91: AnsiString;
  v137: LongInt;
  v138: AnsiString;
  v690: Boolean;
  v691: Int64;
  v692: LongInt;
  v696: Boolean;
  v693: Boolean;
  v694: Boolean;
  v699: TUS0;
  v713: AnsiString;
  v700: LongInt;
  v714: AnsiString;
  v715: Boolean;
  v716: Int64;
  v717: LongInt;
  v721: Boolean;
  v718: Boolean;
  v719: Boolean;
  v724: TUS0;
  v726: AnsiString;
  v725: LongInt;
  v727: AnsiString;
  v728: Boolean;
  v729: Int64;
  v730: LongInt;
  v734: Boolean;
  v731: Boolean;
  v732: Boolean;
  v737: TUS0;
  v739: AnsiString;
  v738: LongInt;
  v740: AnsiString;
  v741: Boolean;
  v742: Int64;
  v743: LongInt;
  v747: Boolean;
  v744: Boolean;
  v745: Boolean;
  v750: TUS0;
  v752: AnsiString;
  v751: LongInt;
begin
  v0 := 'ff';
  v59 := StrToInt(#36 + v0);
  Writeln(v59);
  v67 := '1011';
  v90 := StrToInt(#37 + v67);
  Writeln(v90);
  v91 := '-42';
  v137 := StrToInt(v91);
  Writeln(v137);
  v138 := ' 123 ';
  v690 := (StrToInt64Def(Trim(v138), 0) = StrToInt64Def(Trim(v138), 1));
  v691 := StrToInt64Def(Trim(v138), 0);
  v692 := LongInt(v691);
  if v690 then begin
      v693 := v691 >= (-2147483648);
      if v693 then begin
          v694 := v691 <= 2147483647;
          v696 := v694;
      end else begin
          v696 := False;
      end;
  end else begin
      v696 := False;
  end;
  if v696 then begin
      v699 := US0_0(v692);
  end else begin
      v699 := US0_1;
  end;
  case v699.tag of
      1: begin
          v713 := 'none';
          Writeln(v713);
      end;
      0: begin
          v700 := v699.c0_0;
          Writeln(v700);
      end;
  end;
  v714 := '12x';
  v715 := (StrToInt64Def(Trim(v714), 0) = StrToInt64Def(Trim(v714), 1));
  v716 := StrToInt64Def(Trim(v714), 0);
  v717 := LongInt(v716);
  if v715 then begin
      v718 := v716 >= (-2147483648);
      if v718 then begin
          v719 := v716 <= 2147483647;
          v721 := v719;
      end else begin
          v721 := False;
      end;
  end else begin
      v721 := False;
  end;
  if v721 then begin
      v724 := US0_0(v717);
  end else begin
      v724 := US0_1;
  end;
  case v724.tag of
      1: begin
          v726 := 'none';
          Writeln(v726);
      end;
      0: begin
          v725 := v724.c0_0;
          Writeln(v725);
      end;
  end;
  v727 := '';
  v728 := (StrToInt64Def(Trim(v727), 0) = StrToInt64Def(Trim(v727), 1));
  v729 := StrToInt64Def(Trim(v727), 0);
  v730 := LongInt(v729);
  if v728 then begin
      v731 := v729 >= (-2147483648);
      if v731 then begin
          v732 := v729 <= 2147483647;
          v734 := v732;
      end else begin
          v734 := False;
      end;
  end else begin
      v734 := False;
  end;
  if v734 then begin
      v737 := US0_0(v730);
  end else begin
      v737 := US0_1;
  end;
  case v737.tag of
      1: begin
          v739 := 'none';
          Writeln(v739);
      end;
      0: begin
          v738 := v737.c0_0;
          Writeln(v738);
      end;
  end;
  v740 := '+7';
  v741 := (StrToInt64Def(Trim(v740), 0) = StrToInt64Def(Trim(v740), 1));
  v742 := StrToInt64Def(Trim(v740), 0);
  v743 := LongInt(v742);
  if v741 then begin
      v744 := v742 >= (-2147483648);
      if v744 then begin
          v745 := v742 <= 2147483647;
          v747 := v745;
      end else begin
          v747 := False;
      end;
  end else begin
      v747 := False;
  end;
  if v747 then begin
      v750 := US0_0(v743);
  end else begin
      v750 := US0_1;
  end;
  case v750.tag of
      1: begin
          v752 := 'none';
          Writeln(v752);
      end;
      0: begin
          v751 := v750.c0_0;
          Writeln(v751);
      end;
  end;
  Result := 0;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
