program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
  TMut0 = class l0: AnsiString; end;
function format_real_0(v0: TUS0): AnsiString; forward;
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
function format_real_0(v0: TUS0): AnsiString;
var
  v43: AnsiString;
  v44: TMut0;
  v58: AnsiString;
  v64: AnsiString;
  v86: AnsiString;
begin
  v43 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v44 := MutCreate0(v43);
  v58 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v64 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  ;
  v86 := v44.l0;
  Result := v86;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: AnsiString;
  v24: AnsiString;
  v25: Boolean;
begin
  v0 := 1;
  v1 := US0_0(v0);
  v2 := format_real_0(v1);
  v24 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v25 := v24 = '';
  if v25 then begin
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
