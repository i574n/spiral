program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TMut0 = class;
  TUS0 = record tag: LongInt; c0_0: LongInt; end;
  TMut0 = class l0: AnsiString; end;
function format_real_0(v0: TUS0): AnsiString; forward;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 0; Result.c0_0 := a0;
end;
function US0_None: TUS0;
begin
  Result.tag := 1; 
end;
function MutCreate0(a0: AnsiString): TMut0;
begin
  Result := TMut0.Create; Result.l0 := a0;
end;
function format_real_0(v0: TUS0): AnsiString;
var
  v1: AnsiString;
  v2: TMut0;
  v3: AnsiString;
  v4: AnsiString;
  v5: AnsiString;
begin
  v1 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v2 := MutCreate0(v1);
  v3 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v4 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  ;
  v5 := v2.l0;
  Result := v5;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: AnsiString;
  v3: AnsiString;
  v4: Boolean;
begin
  v0 := 1;
  v1 := US0_Some(v0);
  v2 := format_real_0(v1);
  v3 := backend_switch_has_no_Delphi_arm_in_lib_spiral;
  v4 := v3 = '';
  if v4 then begin
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
