program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUS0 = record tag: LongInt; c1_0: LongInt; end;
  TTuple0 = record f0: TUS0; f1: LongInt; end;
function method0(v0: LongInt): TTuple0; forward;
function US0_None: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Some(a0: LongInt): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
function TupleCreate0(f0: TUS0; f1: LongInt): TTuple0;
begin
  Result.f0 := f0; Result.f1 := f1;
end;
function method0(v0: LongInt): TTuple0;
var
  v1: Boolean;
  v2: TUS0;
  v3: TUS0;
begin
  v1 := v0 = 0;
  if v1 then begin
      v2 := US0_None;
      Result := TupleCreate0(v2, 0);
  end else begin
      v3 := US0_Some(v0);
      Result := TupleCreate0(v3, v0);
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TUS0;
  v2: LongInt;
  tmp3: TTuple0;
  v3: LongInt;
  v4: Boolean;
  v6: Boolean;
  v5: Boolean;
begin
  v0 := 7;
  tmp3 := method0(v0);
  v1 := tmp3.f0;
  v2 := tmp3.f1;
  case v1.tag of
      0: begin
          Result := 1;
      end;
      1: begin
          v3 := v1.c1_0;
          v4 := v3 = 7;
          if v4 then begin
              v5 := v2 = 7;
              v6 := v5;
          end else begin
              v6 := False;
          end;
          if v6 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
