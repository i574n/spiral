program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TUH0 = class;
  TUH0 = class(TSpiralRc) tag: LongInt; c0_0: LongInt; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function is_odd_1(v0: LongInt): Boolean; forward;
function is_even_0(v0: LongInt): Boolean; forward;
function UH0_Cell(a0: LongInt): TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; Result.c0_0 := a0;
end;
function is_odd_1(v0: LongInt): Boolean;
var
  v1: TUH0;
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
begin
  v1 := UH0_Cell(v0);
  case v1.tag of
      0: begin
          v2 := v1.c0_0;
          SpiralRelease(v1);
          v3 := v2 = 0;
          if v3 then begin
              Result := False;
          end else begin
              v4 := v2 - 1;
              Result := is_even_0(v4);
          end;
      end;
  end;
end;
function is_even_0(v0: LongInt): Boolean;
var
  v1: TUH0;
  v2: LongInt;
  v3: Boolean;
  v4: LongInt;
begin
  v1 := UH0_Cell(v0);
  case v1.tag of
      0: begin
          v2 := v1.c0_0;
          SpiralRelease(v1);
          v3 := v2 = 0;
          if v3 then begin
              Result := True;
          end else begin
              v4 := v2 - 1;
              Result := is_odd_1(v4);
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: Boolean;
begin
  v0 := 1000;
  v1 := is_even_0(v0);
  if v1 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
