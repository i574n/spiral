program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
  TMut0 = class l0: AnsiString; end;
function format_real_1(v0: TUS0): AnsiString; forward;
function method0: AnsiString; forward;
function US0_0(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_1: TUS0;
begin
  Result.tag := 1; 
end;
function MutCreate0(a0: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function format_real_1(v0: TUS0): AnsiString;
var
  v44: AnsiString;
  v56: TMut0;
  v70: AnsiString;
  v77: AnsiString;
  v105: AnsiString;
begin
  v44 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v56 := MutCreate0(v44);
  v70 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v77 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  ;
  v105 := v56.l0;
  Result := v105;
end;
function method0: AnsiString;
var
  v0: LongInt;
  v1: TUS0;
  v2: AnsiString;
  v24: AnsiString;
begin
  v0 := 1;
  v1 := US0_0(v0);
  v2 := format_real_1(v1);
  v24 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  Result := v24;
end;
function SpiralMain: LongInt;
var
  v0: AnsiString;
  v1: Boolean;
begin
  v0 := method0;
  v1 := v0 = '';
  if v1 then begin
      Result := 1;
  end else begin
      Result := 0;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
